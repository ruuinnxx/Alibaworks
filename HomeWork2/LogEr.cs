Log("ERROR", "Ошибка error");
Log("WARNING", "Ошибка warning");
Log("INFO", "Ошибка info");
return;

void Log(string exceptionMassage, string message) =>
    Console.WriteLine($"{exceptionMassage}: {message}");
