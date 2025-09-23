using System;

// ----------------- 1. Интерфейс документа -----------------
public interface IDocument
{
    void Open();
}

// ----------------- 2. Конкретные документы -----------------
public class Report : IDocument
{
    public void Open() => Console.WriteLine("Opening Report document...");
}

public class Resume : IDocument
{
    public void Open() => Console.WriteLine("Opening Resume document...");
}

public class Letter : IDocument
{
    public void Open() => Console.WriteLine("Opening Letter document...");
}

// Новый тип документа: Invoice
public class Invoice : IDocument
{
    public void Open() => Console.WriteLine("Opening Invoice document...");
}

// ----------------- 3. Абстрактная фабрика -----------------
public abstract class DocumentCreator
{
    public abstract IDocument CreateDocument();
}

// ----------------- 4. Конкретные фабрики -----------------
public class ReportCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new Report();
}

public class ResumeCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new Resume();
}

public class LetterCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new Letter();
}

public class InvoiceCreator : DocumentCreator
{
    public override IDocument CreateDocument() => new Invoice();
}

// ----------------- 5. Динамический выбор документа -----------------
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter document type (report/resume/letter/invoice):");
        string input = Console.ReadLine()?.ToLower();

        DocumentCreator creator = input switch
        {
            "report" => new ReportCreator(),
            "resume" => new ResumeCreator(),
            "letter" => new LetterCreator(),
            "invoice" => new InvoiceCreator(),
            _ => null
        };

        if (creator == null)
        {
            Console.WriteLine("Unknown document type!");
            return;
        }

        IDocument document = creator.CreateDocument();
        document.Open();
    }
}
