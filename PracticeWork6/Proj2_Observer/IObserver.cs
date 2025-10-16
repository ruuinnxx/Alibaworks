namespace Project2_Observer;

public interface IObserver
{
    void Update(string stockSymbol, decimal price);
}

public interface ISubject
{
    void Attach(string stock, IObserver observable);
    void Detach(string stock, IObserver observable);
    void Notify(string stockSymbol);
}

public class StockExchange : ISubject
{
    
    private readonly Dictionary<string, List<IObserver>> _observers = new ();
    private readonly Dictionary<string, decimal> _stockPrice = new ();

    public void Attach(string stock, IObserver observable)
    {
        _observers[stock] = new List<IObserver>();  
        _observers[stock].Add(observable);
    }

    public void Detach(string stock, IObserver observable)
    {
        _observers[stock].Remove(observable);
    }

    public void Notify(string stockSymbol)
    {
        foreach (var item in _observers[stockSymbol])
        {
            item.Update(stockSymbol, _stockPrice[stockSymbol]);
        }
    }

    public void SetStockPrice(string stockSymbol, decimal newPrice)
    {
        _stockPrice[stockSymbol] = newPrice;
        Console.WriteLine($"Биржа: цена акции {stockSymbol} изменилась на {newPrice}");
        Notify(stockSymbol);
    }
}

public class Trader(string name) : IObserver
{
    private string Name { get; set; } = name;
    public void Update(string stockSymbol, decimal price)
    {
        Console.WriteLine($"Trader {Name} get notify: Stock {stockSymbol} now have new price - {price}");
    }
}

public class TraderBot(decimal buyThreshold, decimal sellThreshold) : IObserver
{
    public void Update(string stockSymbol, decimal price)
    {
        if (price < buyThreshold)
            Console.WriteLine($"Бот покупает {stockSymbol} по цене: {price}");
        else if (price > sellThreshold)
        
            Console.WriteLine($"Бот продает {stockSymbol} по цене {price}");
        else
            Console.WriteLine($"Бот наблюдает за {stockSymbol}, текущая цена {price}");
    }
}