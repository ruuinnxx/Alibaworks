namespace Project1_Singleton;

public class LogReader(Logger logger)
{
    public void Read(LogLevel? filterLevel = null)
    {
        using var sr = new StreamReader(logger.Path);
        while (sr.ReadLine() is { } line)
        {
            if (filterLevel == null || line.Contains($"{filterLevel}"))
                Console.WriteLine(line);
        }
    }
}