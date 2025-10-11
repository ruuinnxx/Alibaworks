namespace Project1_Singelton;

public class Logger
{
   private static Logger? _instance;
   private static readonly Lock Lock = new();
   private LogLevel _currentLevel = LogLevel.Info;
   private const string FilePath = "log.txt";

   private Logger() { }
   
   public static Logger GetInstance()
   {
      if (_instance != null) 
         return _instance;
      
      lock (Lock)
         _instance ??= new Logger();
      
      return _instance;
   }
   
   public void SetLogLevel(LogLevel level) =>
      _currentLevel = level;
   
   public void Log(string message, LogLevel level)
   {
      if (level < _currentLevel) 
         return; 
      
      lock (Lock) 
      {
         using var sw = new StreamWriter(FilePath, true);
         sw.WriteLine($"{DateTime.Now} [{level}] {message}");
      }
   }
}