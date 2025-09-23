public static class AppConfig
{
    public static string ConnectionString =
        "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
}

public class DatabaseService
{
    public void Connect()
    {
        string connectionString = AppConfig.ConnectionString;
        // Логика подключения к базе данных
    }
}

public class LoggingService
{
    public void Log(string message)
    {
        string connectionString = AppConfig.ConnectionString;
        // Логика записи лога в базу данных
    }
}
