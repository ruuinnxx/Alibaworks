using System.Net;

namespace PatternsHomework.Builder
{
    public class HtmlReportBuilder : IReportBuilder
    {
        private Report _report = new();

        public void Reset() => _report = new Report();

        public void SetHeader(string header)
        {
            _report.Header = $"<h1>{WebUtility.HtmlEncode(header)}</h1>";
        }

        public void SetContent(string content)
        {
            _report.Content = $"<div>{WebUtility.HtmlEncode(content).Replace("\n", "<br/>")}</div>";
        }

        public void SetFooter(string footer)
        {
            _report.Footer = $"<footer>{WebUtility.HtmlEncode(footer)}</footer>";
        }

        public Report GetReport()
        {
            var r = _report;
            Reset();
            return r;
        }
    }
}
