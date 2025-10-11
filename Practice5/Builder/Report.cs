namespace Project2_Builder;

public class Report
{
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public Dictionary<string, string> Sections { get; } = new();
        public ReportStyle Style { get; set; } = new();


        public void Export(string format)
        { 
                Console.WriteLine($"=== Export {format} Report ===");
                Console.WriteLine($"Header: {Header}");
                Console.WriteLine($"Content: {Content}");
                foreach (var section in Sections)
                    Console.WriteLine($"Sections: {section.Key} -> {section.Value}"); 
                Console.WriteLine($"Footer: {Footer}");
                Console.WriteLine($"Applied: {Style}");

                Console.WriteLine();
        }
        
        
}