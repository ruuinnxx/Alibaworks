﻿#region Клиентский код

Beverage tea = new Tea();
Console.WriteLine("=== Приготовление чая ===");
tea.PrepareRecipe();
Console.WriteLine();

Beverage coffee = new Coffee();
Console.WriteLine("=== Приготовление кофе ===");
coffee.PrepareRecipe();
Console.WriteLine();

Beverage hotChocolate = new HotChocolate();
Console.WriteLine("=== Приготовление горячего шоколада ===");
hotChocolate.PrepareRecipe();
Console.WriteLine();

Console.WriteLine("Все напитки успешно приготовлены!");

#endregion

#region Абстрактный класс 
public abstract class Beverage
{
    public virtual void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();

        if (CustomerWantsCondiments())
            AddCondiments();
        else
            Console.WriteLine("Добавки не добавляются.");
    }

    private void BoilWater() =>
        Console.WriteLine("Кипячение воды...");

    public void PourInCup() =>
        Console.WriteLine("Наливание в чашку...");

    protected abstract void Brew();
    protected abstract void AddCondiments();

    protected virtual bool CustomerWantsCondiments()
    {
        while (true)
        {
            Console.Write("Добавить добавки? (1 - Да, 0 - Нет): ");
            var input = Console.ReadLine()?.Trim();

            if (input == "1" || input?.ToLower() == "да" || input?.ToLower() == "y")
                return true;

            if (input == "0" || input?.ToLower() == "нет" || input?.ToLower() == "n")
                return false;

            Console.WriteLine("Некорректный ввод. Введите 1 (Да) или 0 (Нет).");
        }
    }
}

#endregion

#region Классы напитков

public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание чая...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление лимона...");
    }
}

public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Заваривание кофе...");
    }

    protected override void AddCondiments()
    {
        bool addSugar = AskYesNo("Добавить сахар? (1 - Да, 0 - Нет): ");
        if (addSugar)
            Console.WriteLine("Добавлен сахар.");

        bool addMilk = AskYesNo("Добавить молоко? (1 - Да, 0 - Нет): ");
        if (addMilk)
            Console.WriteLine("Добавлено молоко.");

        if (!addSugar && !addMilk)
            Console.WriteLine("Добавки не выбраны.");
    }

    private bool AskYesNo(string message)
    {
        while (true)
        {
            Console.Write(message);
            var input = Console.ReadLine()?.Trim();

            if (input == "1" || input?.ToLower() == "да" || input?.ToLower() == "y")
                return true;

            if (input == "0" || input?.ToLower() == "нет" || input?.ToLower() == "n")
                return false;

            Console.WriteLine("Некорректный ввод. Введите 1 (Да) или 0 (Нет).");
        }
    }
}

public class HotChocolate : Beverage
{
    public override void PrepareRecipe()
    {
        Console.WriteLine("Подогрев молока...");
        Brew();
        if (CustomerWantsCondiments())
            AddCondiments();
        PourInCup();
    }

    protected override void Brew()
    {
        Console.WriteLine("Добавление шоколадного порошка и перемешивание...");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавление маршмеллоу...");
    }
}

#endregion

