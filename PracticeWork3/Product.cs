namespace Project1_Order;

public class Product(int id, string name, double price)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public double Price { get; set; } = price;
}

