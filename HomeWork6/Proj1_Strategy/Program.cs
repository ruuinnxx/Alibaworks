﻿var context = new PaymentContext();

while (true)
{
    Console.WriteLine("Выберите способ оплаты" +
                      "\n1 - PayPal" +
                      "\n2 - CreditCard" +
                      "\n3 - Crypto");
    var strategy = Console.ReadLine();
    switch (strategy)
    {
        case "1":
            context.SetStrategy(new PayPal());
            break;
        case "2":
            context.SetStrategy(new CreditCard());
            break;
        case "3":
            context.SetStrategy(new Crypto());
            break;
        default: 
            throw new Exception("Нет такого выбора");
    }

    context.PayStrategy(5000);
    Console.WriteLine();
}

public interface IPaymentStrategy
{
    void Pay(decimal sum);
}

public class PayPal : IPaymentStrategy
{
    public void Pay(decimal sum)
    {
        Console.WriteLine("Оплата: PayPal");
    }
}

public class CreditCard : IPaymentStrategy
{
    public void Pay(decimal sum)
    {
        Console.WriteLine("Оплата: Кредитная карта");
    }
}

public class Crypto : IPaymentStrategy
{
    public void Pay(decimal sum)
    {
        Console.WriteLine("Оплата: Криптовалюта");
    }
}

public class PaymentContext
{
    private IPaymentStrategy? _paymentStrategy;
    
    public void SetStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    public void PayStrategy(int sum)
    {
        if (_paymentStrategy == null) 
            return;
        Console.WriteLine($"Выбрана: {_paymentStrategy} стратегия");
        _paymentStrategy.Pay(sum);
        Console.WriteLine("Оплата прошла успешна");
    }
}
