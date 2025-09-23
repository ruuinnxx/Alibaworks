using System;

// ----------------- 1. Интерфейс транспорта -----------------
public interface IVehicle
{
    void Drive();
    void Refuel();
}

// ----------------- 2. Конкретные классы транспорта -----------------
public class Car : IVehicle
{
    public string Brand { get; }
    public string Model { get; }
    public string FuelType { get; }

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public void Drive() => Console.WriteLine($"Car {Brand} {Model} is driving.");
    public void Refuel() => Console.WriteLine($"Car {Brand} {Model} is refueling with {FuelType}.");
}

public class Motorcycle : IVehicle
{
    public string Type { get; }
    public int EngineVolume { get; }

    public Motorcycle(string type, int engineVolume)
    {
        Type = type;
        EngineVolume = engineVolume;
    }

    public void Drive() => Console.WriteLine($"{Type} motorcycle with {EngineVolume}cc engine is driving.");
    public void Refuel() => Console.WriteLine($"{Type} motorcycle is refueling.");
}

public class Truck : IVehicle
{
    public int Capacity { get; }
    public int Axles { get; }

    public Truck(int capacity, int axles)
    {
        Capacity = capacity;
        Axles = axles;
    }

    public void Drive() => Console.WriteLine($"Truck with {Capacity} tons capacity and {Axles} axles is driving.");
    public void Refuel() => Console.WriteLine("Truck is refueling with diesel.");
}

// Новый транспорт: Автобус
public class Bus : IVehicle
{
    public int Seats { get; }
    public string Route { get; }

    public Bus(int seats, string route)
    {
        Seats = seats;
        Route = route;
    }

    public void Drive() => Console.WriteLine($"Bus with {Seats} seats is driving on route {Route}.");
    public void Refuel() => Console.WriteLine("Bus is refueling with gas.");
}

// Новый транспорт: Электросамокат
public class ElectricScooter : IVehicle
{
    public int BatteryCapacity { get; }
    public string Model { get; }

    public ElectricScooter(string model, int batteryCapacity)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
    }

    public void Drive() => Console.WriteLine($"Electric scooter {Model} with {BatteryCapacity}Wh battery is driving.");
    public void Refuel() => Console.WriteLine($"Electric scooter {Model} is charging battery.");
}

// ----------------- 3. Абстрактная фабрика -----------------
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

// ----------------- 4. Конкретные фабрики -----------------
public class CarFactory : VehicleFactory
{
    private readonly string _brand, _model, _fuel;
    public CarFactory(string brand, string model, string fuel)
    {
        _brand = brand; _model = model; _fuel = fuel;
    }
    public override IVehicle CreateVehicle() => new Car(_brand, _model, _fuel);
}

public class MotorcycleFactory : VehicleFactory
{
    private readonly string _type; private readonly int _engineVolume;
    public MotorcycleFactory(string type, int engineVolume)
    {
        _type = type; _engineVolume = engineVolume;
    }
    public override IVehicle CreateVehicle() => new Motorcycle(_type, _engineVolume);
}

public class TruckFactory : VehicleFactory
{
    private readonly int _capacity; private readonly int _axles;
    public TruckFactory(int capacity, int axles)
    {
        _capacity = capacity; _axles = axles;
    }
    public override IVehicle CreateVehicle() => new Truck(_capacity, _axles);
}

public class BusFactory : VehicleFactory
{
    private readonly int _seats; private readonly string _route;
    public BusFactory(int seats, string route)
    {
        _seats = seats; _route = route;
    }
    public override IVehicle CreateVehicle() => new Bus(_seats, _route);
}

public class ElectricScooterFactory : VehicleFactory
{
    private readonly string _model; private readonly int _batteryCapacity;
    public ElectricScooterFactory(string model, int batteryCapacity)
    {
        _model = model; _batteryCapacity = batteryCapacity;
    }
    public override IVehicle CreateVehicle() => new ElectricScooter(_model, _batteryCapacity);
}

// ----------------- 5. Динамическое создание транспорта -----------------
class Program
{
    static void Main()
    {
        Console.WriteLine("Choose vehicle type (car/motorcycle/truck/bus/scooter):");
        string choice = Console.ReadLine()?.ToLower();
        VehicleFactory factory = null;

        switch (choice)
        {
            case "car":
                Console.Write("Enter brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter model: ");
                string model = Console.ReadLine();
                Console.Write("Enter fuel type: ");
                string fuel = Console.ReadLine();
                factory = new CarFactory(brand, model, fuel);
                break;

            case "motorcycle":
                Console.Write("Enter type (sport/touring/etc): ");
                string type = Console.ReadLine();
                Console.Write("Enter engine volume (cc): ");
                int volume = int.Parse(Console.ReadLine());
                factory = new MotorcycleFactory(type, volume);
                break;

            case "truck":
                Console.Write("Enter capacity (tons): ");
                int capacity = int.Parse(Console.ReadLine());
                Console.Write("Enter number of axles: ");
                int axles = int.Parse(Console.ReadLine());
                factory = new TruckFactory(capacity, axles);
                break;

            case "bus":
                Console.Write("Enter number of seats: ");
                int seats = int.Parse(Console.ReadLine());
                Console.Write("Enter route name: ");
                string route = Console.ReadLine();
                factory = new BusFactory(seats, route);
                break;

            case "scooter":
                Console.Write("Enter model: ");
                string scooterModel = Console.ReadLine();
                Console.Write("Enter battery capacity (Wh): ");
                int battery = int.Parse(Console.ReadLine());
                factory = new ElectricScooterFactory(scooterModel, battery);
                break;

            default:
                Console.WriteLine("Unknown vehicle type!");
                return;
        }

        IVehicle vehicle = factory.CreateVehicle();
        vehicle.Drive();
        vehicle.Refuel();
    }
}
