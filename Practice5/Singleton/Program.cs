using Project1_Singleton;

var logger = Logger.GetInstance();
logger.SetLogLevel(LogLevel.Info);

var threads = new List<Thread>();

for (var i = 0; i < 5; i++)
{
    var id = 1;
    var thread = new Thread(() =>
    {
        logger.Log($"Message from thread {id}", (LogLevel)(id % 3));
    });
    threads.Add(thread);
    thread.Start();
}

foreach (var thread in threads)
{
    thread.Join();
}

var reader = new LogReader(logger);
Console.WriteLine("=== Error ===");
reader.Read(LogLevel.Error);