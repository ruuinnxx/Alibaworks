﻿using Project1_Singelton;

var logger = Logger.GetInstance();
logger.SetLogLevel(LogLevel.Info); 

var threads = new List<Thread>();

for (var i = 0; i < 5; i++)
{
    var id = i;
    var thread = new Thread(() =>
    {
        var log = Logger.GetInstance();
        log.Log($"Сообщение от потока {id} (INFO)", LogLevel.Info);
        log.Log($"Предупреждение от потока {id}", LogLevel.Warning);
        log.Log($"Ошибка от потока {id}", LogLevel.Error);
    });
    threads.Add(thread);
    thread.Start();
}

foreach (var t in threads)
    t.Join();

Console.WriteLine("Логирование завершено");