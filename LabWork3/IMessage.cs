var emailMessage = new SendMessage(new EmailNotification());
Console.WriteLine(emailMessage.SendMess("Email message"));

var smsMessage = new SendMessage(new SmsNotification());
Console.WriteLine(smsMessage.SendMess("Sms Message"));

public interface INotification
{
    string SendNotification(string message);
}

public class EmailNotification : INotification
{
    public string SendNotification(string message) => 
        message;
}

public class SmsNotification : INotification
{
    public string SendNotification(string message) =>
        message;
}

public class SendMessage(INotification notification)
{
    public string SendMess(string message)
    {
        Console.WriteLine("Отправка сообщения");
        return notification.SendNotification(message);
    }
}