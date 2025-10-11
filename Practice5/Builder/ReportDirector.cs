namespace Project2_Builder;

public class ReportDirector
{
    public Report ConstructReport(IReportBuilder builder, ReportStyle style)
    {
        builder.SetStyle(style);
        builder.SetHeader("Отчёт по продажам");
        builder.SetContent("Содержимое отчёта с динамическими данными.");
        builder.AddSection("Раздел 1", "Данные по региону A.");
        builder.AddSection("Раздел 2", "Данные по региону B.");
        builder.SetFooter("Конец отчёта.");
        return builder.GetReport();
    }
}