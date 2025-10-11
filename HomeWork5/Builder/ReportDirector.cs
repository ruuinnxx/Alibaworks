namespace PatternsHomework.Builder
{
    public class ReportDirector
    {
        public void ConstructBasicReport(IReportBuilder builder, string header, string content, string footer)
        {
            builder.SetHeader(header);
            builder.SetContent(content);
            builder.SetFooter(footer);
        }

        public void ConstructContentOnlyReport(IReportBuilder builder, string content)
        {
            builder.SetHeader(string.Empty);
            builder.SetContent(content);
            builder.SetFooter(string.Empty);
        }
    }
}
