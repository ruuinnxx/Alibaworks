using Project1_Order;

try
{
    var products = new List<Product?>
    {
        new(1, "product 1", 30.000),
        new(2, "product 2", 9.000),
        new(3, "product 3", 100.000)
    };
    var order = new Order(products);

    Console.WriteLine("Выберите товар:");
    foreach (var p in products)
        Console.WriteLine($"Id: {p!.Id}, Name: {p.Name}, Price: {p.Price}");
    
    Console.WriteLine("Введите ID товара: ");
    var userProductId = Console.ReadLine();

    
    if (!int.TryParse(userProductId, out var id))
        Console.WriteLine("Введите число");
    
    var product =  products.FirstOrDefault(p => p!.Id == id);
    order.AddProduct(product);
    
    Console.WriteLine("Скидка покупателя" +
                      "\n1-Silver" +
                      "\n2-Gold" +
                      "\n3-Platinum");
    
    var discount = Console.ReadLine() switch
    {

        "1" => new DiscountCalculate(new SilverCustomer()),
        "2" => new DiscountCalculate(new GoldCustomer()),
        "3" => new DiscountCalculate(new PlatinumCustomer()),
        _ => new DiscountCalculate(new SilverCustomer())
    };

    var discountPrice = discount.CalculateDiscount(order.TotalPrice);
    
    Console.WriteLine("Выберите способ оплаты: " +
                      "\n1-Кредитная крата" +
                      "\n2-PayPal" +
                      "\n3-BankTransfer");

    var payment = Console.ReadLine() switch
    {
        "1" => new Payment(new CreditCard()),
        "2" => new Payment(new PayPal()),
        "3" => new Payment(new BankTransfer()),
        _ => new Payment(new CreditCard())
    };
    payment.PaymentMethod(discountPrice);


    Console.WriteLine("Выберите способ доставки" +
                      "\n1-Почта" +
                      "\n2-Курьер" +
                      "\n3-Пикап");


    IDelivery delivery = Console.ReadLine() switch
    {
        "1" => new PostDelivery(),
        "2" => new CourierDelivery(),
        "3" => new PickUpPointDelivery(),
        _ => new CourierDelivery()
    };
    delivery.DeliveryOrder(order);

    var notification = new EmailNotification();
    notification.SendNotification("Ваш заказ оформлен");

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    throw;
}