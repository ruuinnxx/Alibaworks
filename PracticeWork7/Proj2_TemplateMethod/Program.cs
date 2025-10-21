﻿var pdf = new PdfReport();
var excel = new ExcelReport();
var html = new HtmlReport();
var cvs = new CsvReport();

Console.WriteLine("Отчет: PDF");
pdf.PreparedReport();

Console.WriteLine("\nОтчет: Excel");
excel.PreparedReport();

Console.WriteLine("\nОтчет: Html");
html.PreparedReport();

Console.WriteLine("\nОтчет: Cvs");
cvs.PreparedReport();
public abstract class ReportGenerator
{
    public void PreparedReport()
    {
        CreateReport();
        ReportFormatting();
        DataStructure();
        if (HasHook())
            HookAction();
        SaveReport();
    }
    
    public void CreateReport()
    {
        Console.WriteLine("Создание отчета");
    }

    public void SaveReport()
    {
        Console.WriteLine("Сохранение отчета");
    }

    public abstract void ReportFormatting();
    public abstract void DataStructure();

    public virtual bool HasHook() => false;
    public virtual void HookAction() { }
}

#region Конкретные классы

public class PdfReport : ReportGenerator
{
    public override void ReportFormatting()
    {
        Console.WriteLine("Формат отчета: PDF");
    }

    public override void DataStructure()
    {
        Console.WriteLine("Структура: текстовая");
    }

    public override bool HasHook() => true;

    public override void HookAction()
    {
        Console.WriteLine("Hook: изменен текст PDF-файла ");
    }
}

public class ExcelReport : ReportGenerator
{
    public override void ReportFormatting()
    {
        Console.WriteLine("Формат отчета: Excel");
    }

    public override void DataStructure()
    {
        Console.WriteLine("Структура: табличная");
    }
}

public class HtmlReport : ReportGenerator
{
    public override void ReportFormatting()
    {
        Console.WriteLine("Формат отчета: HTML");
    }

    public override void DataStructure()
    {
        Console.WriteLine("Структура: web-страница");
    }

    public override bool HasHook() => true;

    public override void HookAction()
    {
        Console.WriteLine("Hook: Добавлены стили CSS");
    }
}

public class CsvReport : ReportGenerator
{
    public override void ReportFormatting()
    {
        Console.WriteLine("Формат отчета: CSV");
    }

    public override void DataStructure()
    {
        Console.WriteLine("Структура: список строк");

    }
}

#endregion