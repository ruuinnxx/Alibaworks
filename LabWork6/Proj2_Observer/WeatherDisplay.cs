namespace Project2_Observer;

public class WeatherDisplay(string name) : IObserver
{
    public void Update(float temperature)
    {
        Console.WriteLine($"{name} показывает новую температуру: {temperature}°C");
    }
}