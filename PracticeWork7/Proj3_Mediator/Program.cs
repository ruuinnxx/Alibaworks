﻿var channelMediator = new ChannelMediator();

var studentsChannel = channelMediator.CreateChannel("Студенты");
var teacherChannels = channelMediator.CreateChannel("Преподаватели");

Console.WriteLine();

var user1 = new User("user1", studentsChannel);
var user2 = new User("user2", studentsChannel);
var user3 = new User("user3", studentsChannel);
var user4 = new User("user4", teacherChannels);
var user5 = new User("user5", teacherChannels);

studentsChannel.AddUser(user1);
studentsChannel.AddUser(user2);
studentsChannel.AddUser(user3);

teacherChannels.AddUser(user4);
teacherChannels.AddUser(user5);

Console.WriteLine();

user1.Send("Всем привет от user1");
user2.Send("Привет user1 от user2");
user3.Send("Джависты лучше всех");

studentsChannel.RemoveUser(user3);

Console.WriteLine();

user4.Send("Го по бокалу после работы");
user5.Send("Давай, только по одной )");



public interface IMediator
{
    void AddUser(IUser user);
    void RemoveUser(IUser user);
    void Send(string message, IUser sender);
    
    public void Notify(string message);
}

public interface IUser
{
    string Name { get; }
    void Send(string message);
    void Receive(string message);
}

public class ChatMediator : IMediator
{
    private readonly List<IUser> _users = new();
    public void AddUser(IUser user)
    {
        _users.Add(user);
        Console.WriteLine($"{user.Name} вошел в чат");
    }

    public void RemoveUser(IUser user)
    {
        _users.Remove(user);
        Console.WriteLine($"{user.Name} покинул чат");
    }

    public void Send(string message, IUser sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive($"{sender.Name}: {message}");
        }
    }

    public void Notify(string message)
    {
        foreach (var user in _users)
        {
            user.Receive($"Система: {message}");
        }
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

    public void Receive(string message)
    {
        Console.WriteLine($"Получено {Name}: {message}");
    }
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

