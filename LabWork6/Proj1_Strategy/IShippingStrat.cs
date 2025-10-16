namespace Project1_Strategy;

public interface IShippingStrategy
{
    decimal CalculateShippingCost(decimal weight, decimal distance);
}

public class StandardShippingStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(decimal weight, decimal distance)
    {
        return weight * 0.5m + distance * 0.1m;
    }
}

public class ExpressShippingStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(decimal weight, decimal distance)
    {
        return weight * 0.75m + distance * 0.2m + 10;
    }
}

public class InternationalShippingStrategy : IShippingStrategy
{
    public decimal CalculateShippingCost(decimal weight, decimal distance)
    {
        return weight * 1 + distance * 0.5m + 15;
    }
}

public class OvernightDelivery : IShippingStrategy
{
    public decimal CalculateShippingCost(decimal weight, decimal distance)
    {
        return weight * 1.2m + distance * 0.7m + 20;
    }
}

public class DeliveryContext
{
    private IShippingStrategy _shipping;

    public void SetShippingStrategy(IShippingStrategy strategy)
    {
        _shipping = strategy;
    }

    public decimal CalculateCost()
    {
        while (true)
        {
            if (_shipping == null)
            {
                throw new InvalidOperationException("Стратегия доставки не установлена");
            }

            try
            {
                Console.WriteLine("Введите вес посылки (кг):");
                var weight = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Введите расстояние доставки (км):");
                var distance = Convert.ToDecimal(Console.ReadLine());
                
                if (weight >= 0 && distance >= 0)
                    return _shipping.CalculateShippingCost(weight, distance);
                
                Console.WriteLine("Не корректные данные, попытку"); 
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка: {e.Message}");       
            }
        }
    }
}