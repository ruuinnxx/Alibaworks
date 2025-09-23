namespace Project1_Order;

public interface INotification
{
    void SendNotification(string message);
}

public class EmailNotification : INotification
{
    public void SendNotification(string message) =>
        Console.WriteLine($"Email: {message}");
}

public class SmsNotification : INotification
{
    public void SendNotification(string message) =>
        Console.WriteLine($"Sms: {message}");
}