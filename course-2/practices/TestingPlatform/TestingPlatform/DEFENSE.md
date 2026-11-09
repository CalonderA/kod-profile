# Шпаргалка к защите самостоятельной работы

## Часть 1. Демонстрация (порядок показа)

### 1.1. Запуск проекта
```bash
cd C:\Users\andro\TestingPlatform
dotnet run
```
При старте приложение **само применяет миграции** — это настраивается в `Program.cs`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();   // <- применяет все неприменённые миграции при запуске
}
```

### 1.2. Миграции (если спросят команды)
```bash
dotnet ef migrations add ИмяМиграции   # создать миграцию (файл в папке Migrations/)
dotnet ef database update              # применить миграцию к БД
```
Миграции в проекте (папка `Migrations/`):
- `Initial` — единственная миграция: создаёт сразу все 21 таблицу (Users, Students, Groups, Courses, Directions, Projects, Tests, Questions, Answers, Attempts, UserAttemptAnswers, UserSelectedOptions, UserTextAnswers, TestResults + join-таблицы test_students, test_groups, test_projects, test_courses, test_directions, GroupStudent) с первичными данными справочников

**Быстрая проверка «с нуля»:** удалить файл `testing.db` и запустить `dotnet run` — база создастся заново автоматически (сначала показать это преподавателю — сильный ход).

### 1.3. Показ структуры БД (DB Browser for SQLite)
1. Остановить приложение (Ctrl+C) — иначе файл базы занят.
2. Открыть `C:\Users\andro\TestingPlatform\testing.db` в DB Browser.
3. Вкладка **«Структура БД»** — список таблиц и индексов (IX_*).
4. Вкладка **«Данные»** — содержимое: показать Projects (КОД, ПАЗЛ), Directions, Courses, Users, Students, Groups.
5. Вкладка **«Выполнить SQL»** — показать внешний ключ и индексы запросом:
```sql
SELECT sql FROM sqlite_master WHERE name = 'Groups';
-- покажет CREATE TABLE с FOREIGN KEY ... ON DELETE RESTRICT
SELECT sql FROM sqlite_master WHERE name = 'Students';
-- FOREIGN KEY (UserId) REFERENCES Users (Id) ON DELETE CASCADE
```

Наглядная демонстрация Restrict (в DB Browser, Execute SQL):
```sql
DELETE FROM Directions WHERE Id = 1;  -- ошибка FOREIGN KEY constraint failed,
                                      -- т.к. группа КП-15 привязана к направлению "Фронтенд"
```

---

## Часть 2. Ответы по критериям

### Критерий 1. Модели предметной области
**Где смотреть:** папка `Models/` (User, Student, Group, Project, Course, Direction) и `Enums/UserRole.cs`.

- **Какую задачу решает модель?** User — общие данные любого человека в системе (логин, email, ФИО, роль). Student — только специфичные для студента поля (телефон, ВК). Разделение нужно потому, что в системе есть и менеджеры — им телефон/ВК не нужны.
- **Почему такой тип?** `int Id` — суррогатный ключ, автоинкремент в БД. `DateTimeOffset CreatedAt` — дата с часовым поясом, чтобы время не «плавало» в разных зонах. `string? MiddleName` — nullable: отчество может отсутствовать.
- **Что произойдёт, если сделать поле nullable?** В БД колонка станет `NULL`-допустимой, а в C# придётся проверять на null (например, `user.MiddleName ?? ""`). Обязательные поля (Login, Email) — non-nullable + `IsRequired()` = NOT NULL в БД.
- **Зачем enum UserRole?** Чтобы роль не была «магической строкой»: компилятор не даст написать несуществующую роль, в коде читается `UserRole.Student`, а в БД хранится числом (Manager = 1, Student = 2).
- **TestType / AnswerType (если спросят — в полном задании):** такие же enum, как UserRole. Хранить их в БД лучше **строкой** через `HasConversion<string>()`: значения в таблице читаются человеком («SingleChoice» вместо «2»), и при добавлении нового значения в середину enum числа не «поедут».

### Критерий 2. Связи между сущностями
**Где смотреть:** `Data/AppDbContext.cs`, блоки `e.HasOne(...)`.

- **Связь 1:1 — User ↔ Student:** `HasOne(x => x.Student).WithOne(s => s.User).HasForeignKey<Student>(s => s.UserId)`. Внешний ключ `UserId` лежит в таблице **Students** (на стороне «зависимой»). Почему именно 1:1: один пользователь-студент имеет ровно одну запись студента.
- **Почему Student.UserId должен быть уникальным?** Уникальный индекс `IX_Students_UserId` (виден в DB Browser) не даёт двум студентам сослаться на одного пользователя. Если убрать уникальность — связь превратится в 1:many: один User мог бы иметь несколько записей Student.
- **Связь 1:many — Direction/Course/Project ↔ Group:** «один» — справочник (одно направление), «много» — группы. Внешние ключи `DirectionId`, `CourseId`, `ProjectId` находятся в таблице **Groups** — всегда на стороне «многих». Навигации: у Group — `Direction`, у Direction — список `List<Group> Groups`.
- **many:many и join-таблицы (test_students, test_projects и т.п. — из полного задания):** связь «многие ко многим» в реляционных БД хранится через отдельную (join) таблицу, в которой лежат пары внешних ключей. Пример: `test_students (TestId, StudentId)`. Если один тест назначить трём студентам — в `test_students` появится **3 строки** с одним и тем же TestId и разными StudentId. Отдельные join-таблицы для назначений тестов нужны, потому что у назначения может появиться собственная информация (дата назначения, дедлайн, кто назначил) — в «чистой» many:many её хранить негде.

### Критерий 3. Ограничения и конфигурация
**Где смотреть:** `Data/AppDbContext.cs`.

- **Уникальные индексы:** `e.HasIndex(x => x.Login).IsUnique()` — логин и email уникальны у пользователей; `Name` уникален у Group, Project, Course, Direction. Если убрать `IsUnique()` — EF не создаст индекс, и БД разрешит дубликаты.
- **Составной уникальный индекс (TestId, Number) — из полного задания:** гарантирует, что **внутри одного теста** номера вопросов не повторяются. Нельзя сделать уникальным только Number: тогда номер 1 сможет существовать лишь в одном тесте во всей системе. Если создать два вопроса с номером 1 в одном тесте — БД отклонит второй (`UNIQUE constraint failed`).
- **HasMaxLength(30):** ограничение длины строки (телефон). В SQLite не влияет на схему (всё TEXT), но в серверных БД станет `nvarchar(30)`, и EF проверяет длину при валидации.
- **Значение по умолчанию:** `e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP")` — значение задаёт **база данных** при вставке, если поле не передано. Отличие от дефолта в C# (`= DateTimeOffset.UtcNow`): C#-дефолт подставляется **до** отправки в БД (значение всегда отправляется), а дефолт БД — это правило самой таблицы, работает даже для вставок мимо приложения (например, из DB Browser).
- **Что фактически в БД?** enum-свойство без настройки хранится как целое число (Role = 2); с `HasConversion<string>()` — как строка ("Student"); CreatedAt — TEXT ("2026-10-07 12:55:16").

### Критерий 4. Поведение базы данных
**Где смотреть:** `OnModelCreating`, параметр `OnDelete(...)`.

- **Cascade** — при удалении главной записи удаляются и зависимые: `DELETE User` → автоматически удаляется его Student.
- **Restrict** — удаление запрещено, пока есть ссылающиеся записи: нельзя удалить Direction, Course, Project, пока к ним привязаны группы (БД вернёт `FOREIGN KEY constraint failed`).
- **Почему Group-FK — Restrict:** справочники защищены от случайного удаления вместе с данными. Чтобы удалить справочник — сначала удаляем/перепривязываем группы. Если поменять Restrict на Cascade — удаление направления молча удалит все его группы.
- **Полное задание (Test/Attempt):** Test → Attempt — Restrict (нельзя удалить тест, по которому есть попытки — потерялась бы история результатов); Question → Test — Cascade (удалили тест — его вопросы не нужны, удаляются сами); Attempt → Student — Cascade; UserAttemptAnswer → Question — Restrict (ответы попыток не должны исчезать при удалении вопроса — это история).
- **Показать в коде:** комментарии в `AppDbContext.cs` прямо над каждой связью.

### Критерий 5. Миграции и итоговая схема
- **Что такое миграция?** Сгенерированный EF-код (класс в `Migrations/`) с методами `Up()` (что создать/изменить) и `Down()` (как откатить) — план изменения схемы БД.
- **Чем миграция отличается от БД?** Миграция — это исходный код, версия схемы; БД (testing.db) — фактическое хранилище. Миграции коммитятся в git, файл БД — нет.
- **Изменил модель без новой миграции?** Схема БД и модель разойдутся: EF будет строить запросы к несуществующим колонкам → ошибки времени выполнения (в EF 9+ при старте ещё и `PendingModelChangesWarning`).
- **Создал миграцию, но не применил?** Файл есть, но БД не изменилась (в таблице `__EFMigrationsHistory` миграция не записана) — применяется при следующем `dotnet ef database update` или `dotnet run` (у нас Migrate() при старте).
- **Показать таблицу по модели:** DB Browser → Данные → таблица Students; внешний ключ — «Структура БД» → Students → FK_Students_Users_UserId (или через `SELECT sql FROM sqlite_master`).

---

## Текущее состояние БД (что покажешь в DB Browser)
- **21 таблица:** Users, Students, Groups, Courses, Directions, Projects, Tests, Questions, Answers, Attempts, UserAttemptAnswers, UserSelectedOptions, UserTextAnswers, TestResults + join-таблицы **test_students, test_groups, test_projects, test_courses, test_directions** + GroupStudent (Student ↔ Group)
- **Справочники заполнены:** Projects (КОД, ПАЗЛ), Directions (Фронтенд/Бэкенд/Дизайн), Courses (1–2 курс)
- **Enum — строками:** Users.Role ("Student"), Tests.Type, Questions.AnswerType — колонки TEXT
- **Составные уникальные индексы:** Questions (TestId, Number), UserAttemptAnswers (AttemptId, QuestionId), TestResults (TestId, StudentId, AttemptId)
- **Уникальные:** Users.Login, Users.Email, названия Group/Course/Project/Direction, Students.UserId (гарантия 1:1), UserTextAnswers.UserAttemptAnswerId
- **Удаления:** 21 × CASCADE (User→Student, Test→Questions→Answers, Student→Attempts, Attempt→UserAttemptAnswers и т.п.), 7 × RESTRICT (Group→справочники, Attempt→Test, UserAttemptAnswer→Question, UserSelectedOption→Answer, TestResult→Test)
- В БД пока только справочники (Users/Students/Groups пусты — старые тестовые данные удалены при пересоздании): создай студента и группу через Swagger — и покажи их в DB Browser
