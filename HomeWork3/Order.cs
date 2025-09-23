using System;

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

// отвечает только за расчёт цены
public class OrderCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        return order.Quantity * order.Price * 0.9; // скидка 10%
    }
}

// отвечает только за оплату
public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails, double amount)
    {
        Console.WriteLine($"Payment of {amount} processed using: {paymentDetails}");
    }
}

// отвечает только за уведомления
public class NotificationService
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine("Confirmation email sent to: " + email);
    }
}
