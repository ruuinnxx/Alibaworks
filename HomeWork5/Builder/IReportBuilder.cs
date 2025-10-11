namespace PatternsHomework.Builder
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        Report GetReport();
        void Reset();
    }
}
