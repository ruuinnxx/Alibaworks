public abstract class Vehicle
{
    public void Start()
    {
        Console.WriteLine($"{GetType().Name} is starting");
    }

    public void Stop()
    {
        Console.WriteLine($"{GetType().Name} is stopping");
    }
}
public class Car : Vehicle { }
public class Truck : Vehicle { }

