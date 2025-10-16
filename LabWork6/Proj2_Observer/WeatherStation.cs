namespace Project2_Observer;

public class WeatherStation : ISubject
{
    private readonly List<IObserver> _observers = new();
    private float _temperature;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(float newTemperature)
    {
        Console.WriteLine($"Изменение температуры: {newTemperature}°C");
        _temperature = newTemperature;
        NotifyObservers();
    }
}