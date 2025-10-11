namespace PatternsHomework.Builder
{
    public class TextReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void Reset() => _report = new Report();

        public void SetHeader(string header) => _report.Header = header;
        public void SetContent(string content) => _report.Content = content;
        public void SetFooter(string footer) => _report.Footer = footer;

        public Report GetReport()
        {
            var r = _report;
            Reset();
            return r;
        }
    }
}
