﻿#region Клиентский код

var chatMediator = new ChatMediator();

var user1 = new User(chatMediator, "user1");
var user2 = new User(chatMediator, "user2");
var user3 = new User(chatMediator, "user3");

chatMediator.RegisterColleague("Общий", user1);
chatMediator.RegisterColleague("Общий", user2);
chatMediator.RegisterColleague("Общий", user3);

user1.Send("Общий", "Привет всем от user1");
user2.Send("Общий", "Привет всем от user2");
user3.Send("Общий", "Привет всем от user3");

chatMediator.ShowChatHistory("Общий");

chatMediator.UnregisterColleague("Общий", user2);
user2.Send("Общий", "Попробую отправить снова");


#endregion

#region Интерфейс и Абстрактный класс

public interface IMediator
{
    void RegisterColleague(string groupName, Colleague colleague);
    void UnregisterColleague(string groupName, Colleague colleague);
    void SendMessage(string groupName, string message, Colleague sender);
    void ShowChatHistory(string groupName);
}


public abstract class Colleague(IMediator mediator, string name)
{
    protected readonly IMediator Mediator = mediator;
    public string Name { get; } = name;

    public abstract void ReceiveMessage(string message);
}

#endregion

#region Конкретный посредник

public class ChatMediator : IMediator
{
    private readonly Dictionary<string, List<Colleague>> _chats = new();
    private readonly Dictionary<string, List<string>> _chatLogs = new();

    public void RegisterColleague(string groupName, Colleague colleague)
    {
        if (!_chats.ContainsKey(groupName))
            _chats[groupName] = [];

        if (!_chats[groupName].Contains(colleague))
            _chats[groupName].Add(colleague);

        Console.WriteLine($"Пользователь '{colleague.Name}' добавлен в группу '{groupName}'");
    }

    public void UnregisterColleague(string groupName, Colleague colleague)
    {
        if (_chats.TryGetValue(groupName, out var value) && value.Remove(colleague))
            Console.WriteLine($"Пользователь '{colleague.Name}' покинул группу '{groupName}'");
        
        else
            Console.WriteLine($"Ошибка: участник '{colleague.Name}' не найден в группе '{groupName}'");
    }

    public void SendMessage(string groupName, string message, Colleague sender)
    {
        if (!_chats.TryGetValue(groupName, out var value))
        {
            Console.WriteLine($"Ошибка: группа '{groupName}' не существует!");
            return;
        }

        if (!value.Contains(sender))
        {
            Console.WriteLine($"Ошибка: пользователь '{sender.Name}' не зарегистрирован в группе '{groupName}'");
            return;
        }

        if (!_chatLogs.ContainsKey(groupName))
            _chatLogs[groupName] = [];

        var logEntry = $"{DateTime.Now:T} [{sender.Name}]: {message}";
        _chatLogs[groupName].Add(logEntry);

        foreach (var colleague in value.Where(c => c != sender))
            colleague.ReceiveMessage($"[{groupName}] {sender.Name}: {message}");
    }

    public void ShowChatHistory(string groupName)
    {
        if (!_chatLogs.TryGetValue(groupName, out var value) || value.Count == 0)
        {
            Console.WriteLine($"История группы '{groupName}' пуста.");
            return;
        }

        Console.WriteLine($"\nИстория сообщений '{groupName}':");
        foreach (var msg in value)
            Console.WriteLine(msg);
        Console.WriteLine();
    }
}


#endregion

#region Конкртеные участники

public class User(IMediator mediator, string name) : Colleague(mediator, name)
{
    public void Send(string groupName, string message)
    {
        Console.WriteLine($"{Name} отправляет сообщение в '{groupName}': {message}");
        Mediator.SendMessage(groupName, message, this);
    }

    public override void ReceiveMessage(string message) =>
        Console.WriteLine($"{Name} получил: {message}");
}

#endregion