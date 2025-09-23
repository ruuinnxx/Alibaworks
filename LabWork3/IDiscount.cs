public interface IDiscountStrategy
{
    double ApplyDiscount(double amount);
}

public class RegularDiscount : IDiscountStrategy
{
    public double ApplyDiscount(double amount) => amount;
}

public class SilverDiscount : IDiscountStrategy
{
    public double ApplyDiscount(double amount) => amount * 0.9;
}

public class GoldDiscount : IDiscountStrategy
{
    public double ApplyDiscount(double amount) => amount * 0.8;
}

// Можно легко добавить PlatinumDiscount без изменения старого кода.

public class DiscountCalculator
{
    private readonly IDiscountStrategy _discountStrategy;

    public DiscountCalculator(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public double Calculate(double amount)
    {
        return _discountStrategy.ApplyDiscount(amount);
    }
}
