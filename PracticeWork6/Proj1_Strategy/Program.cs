﻿using Project1_Strategy;

var context = new TravelBookingContext();

Console.WriteLine("Select transport type:" +
                  "\n1-Airplane" +
                  "\n2-Train" +
                  "\n3-Bus");
var transportChoice = Console.ReadLine()!;

switch (transportChoice)
{
    case "1":
        context.SetCostCalculation(new AirplaneCostStrategy());
        break;
    case "2":
        context.SetCostCalculation(new TrainCostStrategy());
        break;
    case "3":
        context.SetCostCalculation(new BusCostStrategy());
        break;
}  

var cost = context.GetTravelCost(0, 0, "", true);
Console.WriteLine($"Total price: {cost}");