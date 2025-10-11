namespace Project1_Singleton;

public class LoggerConfig
{
    public string LogFilePath { get; set; } = "log.txt";
    public LogLevel Log { get; set; } = LogLevel.Info;
}