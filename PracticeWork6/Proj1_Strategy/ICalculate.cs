namespace Project1_Strategy;

public interface ICalculateCost
{
    decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount);
}

public class AirplaneCostStrategy : ICalculateCost
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        var baseCount = distance * 0.2m;
        if (serviceClass == "Business")
        {
            baseCount *= 1.5m;
        }

        return baseCount;
    }
}

public class TrainCostStrategy : ICalculateCost
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        var baseCount = distance * 0.2m;
        if (serviceClass == "Train")
        {
            baseCount *= 1m;
        }

        return baseCount;
    }
}


public class BusCostStrategy : ICalculateCost
{
    public decimal CalculateCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        var baseCount = distance * 0.2m;
        if (serviceClass == "Bus")
        {
            baseCount *= 0.5m;
        }

        return baseCount;
    }
}

public class TravelBookingContext
{
    private ICalculateCost _strategy;

    public void SetCostCalculation(ICalculateCost strategy) =>
        _strategy = strategy;

    public decimal GetTravelCost(decimal distance, int passenger, string serviceClass, bool hasDiscount)
    {
        if (_strategy != null)
            return _strategy.CalculateCost(distance, passenger, serviceClass, hasDiscount);
        
        throw new Exception("Strategy not selected");
    }
}