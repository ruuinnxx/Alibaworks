using System.Text.Json;

namespace Project1_Singleton;

public class Logger
{
    private static Logger? _logger;
    private static readonly Lock Lock = new();
    private LogLevel _currentLevel;
    public string Path { get; private set; }
    private Logger(LoggerConfig loggerConfig)
    {
        Path = loggerConfig.LogFilePath;
        _currentLevel = loggerConfig.Log;
    }

    

    public static Logger GetInstance(string configPath = "loggerConfig.json")
    {
        if (_logger == null)
        {
            lock (Lock)
            {
                if (_logger == null)
                {
                    LoggerConfig config;
                    if (File.Exists(configPath))
                    {
                        var json = File.ReadAllText(configPath);
                        config = JsonSerializer.Deserialize<LoggerConfig>(json)!;
                    }
                    else
                    {
                        config = new LoggerConfig();
                        File.WriteAllText(configPath, JsonSerializer.Serialize(config, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        }));
                    }
                    _logger = new Logger(config);
                }
            }
        }
        return _logger;
    }

    public void Log(string message, LogLevel level)
    {
        if (level < _currentLevel)
            return;
        lock (Lock)
        {
            using var sw = new StreamWriter(Path, true);
            sw.WriteLine($"{message} - {level}");
        }
    }

    public void SetLogLevel(LogLevel level) =>
        _currentLevel = level;
}

