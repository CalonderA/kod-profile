
//Задание 1
//Создайте файл notes.txt, запишите 3 строки.
//Запишите еще одну строку.
//Прочитайте и выведите содержимое.
//Удалите файл, если подтверждение пользователя “y”.

//Console.Write("Удалить файл? (y/n): ");

string path = @"C:\Users\andro\source\repos\ConsoleApp1\notes.txt.txt";

string fileText = await File.ReadAllTextAsync(path);
Console.WriteLine(fileText);
Console.Write("\nУдалить файл? (y/n): ");
string answer = Console.ReadLine()?.ToLower();

if (answer == "y")
{
    if (File.Exists(path))
    {
        File.Delete(path);
        Console.WriteLine("Файл успешно удален.");
    }
    else
    {
        Console.WriteLine("Файл не существует.");
    }
}
else
{
    Console.WriteLine("Файл сохранен.");
}

//Задание 2
//Создайте каталог data, внутри — несколько .txt файлов.
//Выведите список всех .txt с размерами.
using System.IO;

string dirName = @"C:\Users\andro\source\repos\ConsoleApp1\data";

DirectoryInfo dirInfo = new DirectoryInfo(dirName);
if (dirInfo.Exists)
{

    Console.WriteLine($"Имя файла: {dirInfo.Name}");
    Console.WriteLine($"Размер: {dirName.Length}");
}

//Задание 3. Резервная копия файла
//Попросите пользователя ввести путь к файлу.
//Скопируйте его в тот же каталог с суффиксом .bak, если файл существует.

Console.Write("Путь к файлу: ");
string? src = Console.ReadLine();

if(!string.IsNullOrEmpty(src) && File.Exists(src))
{
    string dir = Path.GetDirectoryName(src)!;
    string name = Path.GetFileName(src);
    string bak = Path.Combine(dir, name + ".bak");
    File.Copy(src, bak,overwrite: true);
    Console.WriteLine($"Создана копия: {bak}");
}
else
{
    Console.WriteLine("Файлы не найден.");
}