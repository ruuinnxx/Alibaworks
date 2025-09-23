var notificationService = new NotificationService(new EmailSender());
notificationService.SendMessage("Hello");
public interface IMessageSender
{
    public void SendMessage(string message);
}

public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class NotificationService(IMessageSender messageSender)
{
    public void SendMessage(string mess)
    {
        messageSender.SendMessage(mess);
    }
}
