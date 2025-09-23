public class OrderService
{
    private double CalculateTotal(int quantity, double price)
    {
        return quantity * price;
    }

    private void PrintOrder(string action, string productName, int quantity, double price)
    {
        double totalPrice = CalculateTotal(quantity, price);
        Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
    }

    public void CreateOrder(string productName, int quantity, double price)
    {
        PrintOrder("created", productName, quantity, price);
    }

    public void UpdateOrder(string productName, int quantity, double price)
    {
        PrintOrder("updated", productName, quantity, price);
    }
}
