namespace Project1_Order;

public interface IDiscount
{
    public double Calculate(double amount);
}

public class SilverCustomer : IDiscount
{
    public double Calculate(double amount) => amount * 0.5;
}

public class GoldCustomer : IDiscount
{
    public double Calculate(double amount) => amount * 0.7;
}
public class PlatinumCustomer : IDiscount
{
    public double Calculate(double amount) => amount * 0.9;
}

public class DiscountCalculate(IDiscount discount)
{
    public double CalculateDiscount(double price) =>
        discount.Calculate(price);
}