
﻿CarFactory? carFactory = null;
Car? car = null;
carFactory?.CreateCar(car);
public interface ITransport
{
    void Move();
    void FuelUp();
}
public class Car(string model, int maxSpeed) : ITransport
{
    public string Model { get; set; } = model;
    public int MaxSpeed { get; set; } = maxSpeed;
    public void Move()
    {
        Console.WriteLine("Машина едет");
    }
    public void FuelUp()
    {
        Console.WriteLine("Машина заправляется");
    }
}
public class Motorcycle(string model, int maxSpeed) : ITransport
{
    public string Model { get; set; } = model;
    public int MaxSpeed { get; set; } = maxSpeed;
    public void Move()
    {
        Console.WriteLine("Мотоцикл едет");
    }
    public void FuelUp()
    {
        Console.WriteLine("Мотоцикл заправляется");
    }
}
public class Plane(string model, int maxSpeed) : ITransport
{
    public string Model { get; set; } = model;
    public int MaxSpeed { get; set; } = maxSpeed;
    public void Move()
    {
        Console.WriteLine("Самолет летит");
    }
    public void FuelUp()
    {
        Console.WriteLine("Самолет заправляется");
    }
}
public class Ship(string model, int maxSpeed) : ITransport
{
    public string Model { get; set; } = model;
    public int MaxSpeed { get; set; } = maxSpeed;
    public void Move()
    {
        Console.WriteLine("Корабль плавает");
    }
    public void FuelUp()
    {
        Console.WriteLine("Корабль заправляется");
    }
}
public abstract class TransportFactory
{
    public ITransport CreateTransport(ITransport transport)
    {
        return transport;
    }
}
public abstract class CarFactory(string model)
{
    public Car? CreateCar(Car? car)
    {
        return car;
    }
}
public abstract class MotorcycleFactory
{
    public Motorcycle CreateCar(Motorcycle motorcycle)
    {
        return motorcycle;
    }
}
public abstract class PlaneFactory
{
    public Plane CreateCar(Plane plane)
    {
        return plane;
    }
}
public abstract class ShipFactory
{
    public Ship CreateShip(Ship ship)
    {
        return ship;
    }
}