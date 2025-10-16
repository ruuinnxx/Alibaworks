﻿using Project1_Strategy;

var deliveryContext = new DeliveryContext();
                    
while (true)
{
    Console.WriteLine("\nВыберите тип доставки: " +
                      "\n1 - Стандартная" +
                      "\n2 - Экспресс" +
                      "\n3 - Международная" +
                      "\n4 - Ночная" +
                      "\n0 - Выйти");
    var choice = Console.ReadLine()!;

    switch (choice)
    {
        case "1":
            deliveryContext.SetShippingStrategy(new StandardShippingStrategy());
            break;
        case "2":
            deliveryContext.SetShippingStrategy(new ExpressShippingStrategy());
            break;
        case "3":
            deliveryContext.SetShippingStrategy(new InternationalShippingStrategy());
            break;
        case "4":
            deliveryContext.SetShippingStrategy(new OvernightDelivery());
            break;
        case "0":
            Console.WriteLine("Выйти");
            return;
        default:
            Console.WriteLine("Нет такого типа, повторите попытку");
            continue;
    }

    var cost = deliveryContext.CalculateCost();
    Console.WriteLine($"Стоимость доставки: {cost}тг");
}