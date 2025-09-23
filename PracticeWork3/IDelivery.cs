namespace Project1_Order;

public interface IDelivery
{
    void DeliveryOrder(Order order);
}

public class PostDelivery : IDelivery
{
    public void DeliveryOrder(Order order) =>
        Console.WriteLine("Доставка осуществляется почтой");
}

public class CourierDelivery : IDelivery
{
    public void DeliveryOrder(Order order) =>
        Console.WriteLine("Доставка осуществляется курьером");
}

public class PickUpPointDelivery : IDelivery
{
    public void DeliveryOrder(Order order) =>
        Console.WriteLine("Доставка осуществляется пикапом");
}