namespace PatternsHomework.Builder
{
    public class Report
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

        public override string ToString()
        {
            return $"Header:\n{Header}\n\nContent:\n{Content}\n\nFooter:\n{Footer}";
        }
    }
}
