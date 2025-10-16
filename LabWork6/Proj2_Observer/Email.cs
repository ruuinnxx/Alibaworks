namespace Project2_Observer;

public class Email(string email) : IObserver
{
    private readonly string _emailAddress = email ?? throw new ArgumentNullException(nameof(email));

    public void Update(float temperature) =>
        Console.WriteLine($"Email показывает новую температуру: {temperature}°C");
    
}