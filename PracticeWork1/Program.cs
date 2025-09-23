Car car = new Car("BMW", "E39", DateTime.Now.AddYears(-10), 4, "МКПП");
car.StartEngine();
car.StopEngine();

Motorcycle motorcycle = new Motorcycle("Honda", "Спортбайк", DateTime.Now.AddYears(-3), "sport", false);
motorcycle.StartEngine();
motorcycle.StopEngine();

Vehicle vehicle = new Vehicle("Toyota", "Camry", DateTime.Now.AddYears(-7));

Garage garage = new Garage();
garage.AddVehicles(vehicle);
garage.DeleteVehicle(vehicle);

Fleet fleet = new Fleet();
fleet.AddGarage(garage);
fleet.SearchVehicle("Honda");


public class Vehicle(string mark, string model, DateTime createDate)
{
    public string Mark { get; set; } = mark;
    private string Model { get; set; } = model;
    private DateTime CreateDate { get; set; } = createDate;

    public void StartEngine() =>
        Console.WriteLine("Двигатель запустился");

    public void StopEngine() =>
        Console.WriteLine("Двигатель заглушен");
}

public class Car(string mark, string model, DateTime createDate, int countDoors, string typeTransmission) 
    : Vehicle(mark, model, createDate)
{
    public int CountDoors { get; set; } = countDoors;
    public string TypeTransmission { get; set; } = typeTransmission;
}

public class Motorcycle(string mark, string model, DateTime createDate, string bodyType, bool availabilityBoxing) 
    : Vehicle(mark, model, createDate)
{
    public string BodyType { get; set; } = bodyType;
    public bool AvailabilityBoxing { get; set; } = availabilityBoxing;
}

public class Garage
{
    public readonly List<Vehicle> Vehicles = new List<Vehicle>();

    public void AddVehicles(Vehicle nameVehicles) =>
        Vehicles.Add(nameVehicles);

    public void DeleteVehicle(Vehicle nameVehicles) =>
        Vehicles.Remove(nameVehicles);
}

public class Fleet
{
    private readonly List<Garage> _garages = new List<Garage>();
    private readonly List<Vehicle> _vehicles = new List<Vehicle>();
    
    public void AddGarage(Garage garage) =>
        _garages.Add(garage);

    public void DeleteGarage(Garage garage) =>
        _garages.Remove(garage);
    
    public Vehicle SearchVehicle(string mark)
    {
        foreach (var item in _vehicles)
        {
            if (mark == item.Mark)
                return item;
        }
        return null;
    }
}
