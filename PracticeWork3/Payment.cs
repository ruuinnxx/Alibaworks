namespace Project1_Order;

public interface IPayment
{
    void ProcessPayment(double amount);
}

public class CreditCard : IPayment
{
    public void ProcessPayment(double amount) =>
        Console.WriteLine("Оплата кредитной картой ");
}

public class PayPal : IPayment
{
    public void ProcessPayment(double amount) =>
        Console.WriteLine("Оплата Pay Pal");
}

public class BankTransfer : IPayment
{
    public void ProcessPayment(double amount) =>
        Console.WriteLine("Оплата банковской картой");
}
public class Payment(IPayment payment)
{
    public void PaymentMethod(double price)
    {
        payment.ProcessPayment(price);
        Console.WriteLine("Оплата прошла успешна");
    }
}