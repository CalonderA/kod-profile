//Задание 3

//1. Создайте интерфейс, реализующий метод ShowInfo:
//public interface IDocumentExporter
//{
//    string FormatName { get; }
//    void Export(string content);

//    void ShowInfo(string content)
//    {
//        Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
//    }
//}

//2.Создайте реализации:
//public class TxtExporter : IDocumentExporter
//{
//    public string FormatName => "TXT";
//    public void Export(string content)
//    {
//        Console.WriteLine("Сохраняем текстовый файл...");
//    }
//}

//public class PdfExporter : IDocumentExporter
//{
//    public string FormatName => "PDF";
//    public void Export(string content)
//    {
//        Console.WriteLine("Создаём PDF-документ...");
//    }
//}


//3.Проверьте работоспособность:

//IDocumentExporter[] exporters =
//{
//    new TxtExporter(),
//    new PdfExporter()
//};

//foreach (var e in exporters)
//{
//    e.ShowInfo("Hello World!");
//    e.Export("Hello World!");
//}


public interface IDocumentExporter
{
    string FormatName { get; }
    void Export(string content);

    void ShowInfo(string content)
    {
        Console.WriteLine($"Экспорт в формат {FormatName}: {content}");
    }
}

public class TxtExporter : IDocumentExporter
{
    public string FormatName => "TXT";
    public void Export(string content)
    {
        Console.WriteLine("Сохраняем текстовый файл...");
    }
}

public class PdfExporter : IDocumentExporter
{
    public string FormatName => "PDF";
    public void Export(string content)
    {
        Console.WriteLine("Создаём PDF-документ...");
    }
}

public class Proggram
{
    public static void Main2(string[] args)
    {
        TextDocument doc = new TextDocument();
        doc.Read("data.txt");
        doc.Write("data.txt", "Привет, мир!");
        doc.Save();
    }
}