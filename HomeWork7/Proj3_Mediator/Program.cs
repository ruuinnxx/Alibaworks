﻿var channelMediator = new ChannelMediator();

var studentsChannel = channelMediator.CreateChannel("Студенты");
var teacherChannel = channelMediator.CreateChannel("Преподаватели");

Console.WriteLine();

var user1 = new User("user1", studentsChannel);
var user2 = new User("user2", studentsChannel);
var user3 = new User("user3", studentsChannel);
var user4 = new User("user4", teacherChannel);
var user5 = new User("user5", teacherChannel);

studentsChannel.AddUser(user1);
studentsChannel.AddUser(user2);
studentsChannel.AddUser(user3);

teacherChannel.AddUser(user4);
teacherChannel.AddUser(user5);

Console.WriteLine();

user1.Send("Всем привет от user1");
user2.Send("Привет user1 от user2");

user1.SendPrivate("user2", "Ты сегодня придешь на лекцию?");
user2.SendPrivate("user1", "Не а");

studentsChannel.RemoveUser(user3);

Console.WriteLine();

user4.Send("Го по бокалу после работы");
user5.SendPrivate("user4", "Давай, только по одной :)");


public interface IMediator
{
    void AddUser(IUser user);
    void RemoveUser(IUser user);
    void Send(string message, IUser sender);
    void SendPrivate(string recipientName, string message, IUser sender);
    void Notify(string message);
}

public interface IUser
{
    string Name { get; }
    void Send(string message);
    void SendPrivate(string recipientName, string message);
    void Receive(string message);
}

public class ChatMediator : IMediator
{
    private readonly List<IUser> _users = new();

    public void AddUser(IUser user)
    {
        if (_users.Contains(user))
        {
            Console.WriteLine($"{user.Name} уже в чате.");
            return;
        }

        _users.Add(user);
        Console.WriteLine($"{user.Name} вошел в чат");
        Notify($"{user.Name} присоединился к чату");
    }

    public void RemoveUser(IUser user)
    {
        if (!_users.Contains(user))
        {
            Console.WriteLine($"{user.Name} не найден в чате.");
            return;
        }

        _users.Remove(user);
        Console.WriteLine($"{user.Name} покинул чат");
        Notify($"{user.Name} покинул чат");
    }

    public void Send(string message, IUser sender)
    {
        if (!_users.Contains(sender))
        {
            Console.WriteLine($"Ошибка: {sender.Name} не состоит в чате, сообщение не отправлено.");
            return;
        }

        foreach (var user in _users.Where(user => user != sender))
            user.Receive($"{sender.Name}: {message}");
    }

    public void SendPrivate(string recipientName, string message, IUser sender)
    {
        if (!_users.Contains(sender))
        {
            Console.WriteLine($"Ошибка: {sender.Name} не может отправить личное сообщение — он не в чате.");
            return;
        }

        var receiver = _users.FirstOrDefault(u =>
            u.Name.Equals(recipientName, StringComparison.OrdinalIgnoreCase));

        if (receiver == null)
        {
            Console.WriteLine($"Ошибка: пользователь '{recipientName}' не найден.");
            return;
        }

        receiver.Receive($"(ЛС от {sender.Name}): {message}");
        Console.WriteLine($"(ЛС {sender.Name} → {recipientName}): {message}");
    }

    public void Notify(string message)
    {
        foreach (var user in _users)
            user.Receive($"Система: {message}");
    }
}

public class User(string name, IMediator mediator) : IUser
{
    public string Name { get; } = name;

    public void Send(string message)
    {
        Console.WriteLine($"Отправлено {Name}: {message}");
        mediator.Send(message, this);
    }

    public void SendPrivate(string recipientName, string message) =>
        mediator.SendPrivate(recipientName, message, this);

    public void Receive(string message) =>
        Console.WriteLine($"Получено {Name}: {message}");
}

public class ChannelMediator
{
    private readonly Dictionary<string, ChatMediator> _channels = new();

    public ChatMediator CreateChannel(string name)
    {
        var channel = new ChatMediator();
        _channels[name] = channel;
        Console.WriteLine($"Создан канал #{name}");
        return channel;
    }
}