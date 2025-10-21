﻿#region Клиентский Код

var product = new Product();

Beverage tea = new Tea(product);
Console.WriteLine("Приготовление чая:");
tea.PrepareRecipe();

Console.WriteLine();

Beverage coffee = new Coffee(product);
Console.WriteLine("Приготовление кофе");
coffee.PrepareRecipe();

Console.WriteLine();

Beverage hotChocolate = new HotChocolate(product);
Console.WriteLine("Приготовление горячего шоколада");
hotChocolate.PrepareRecipe();

#endregion

#region Базовый класс

public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }
    
    private void BoilWater() =>
        Console.WriteLine("Кипячение воды...");
    private void PourInCup() =>
        Console.WriteLine("Наливание в чашку...");
    protected abstract void Brew();
    protected abstract void AddCondiments();
    
}

#endregion

#region Классы наследники

public class Tea(Product product) : Beverage
{
    protected override void AddCondiments()
    {
        if (product.UseIngredient("Заварка"))
            Console.WriteLine("Заваривание чая...");
        else
        {
            Console.WriteLine("Нет заварки");
            product.AddProduct();
        }
    }

    protected override void Brew()
    {
        if (product.UseIngredient("Лимон"))
            Console.WriteLine("Добавление лимона...");
        else
        {
            Console.WriteLine("Нет лимона");
            product.AddProduct();
        }
    }
}


public class Coffee(Product product) : Beverage
{
    protected override void AddCondiments()
    {
        if (product.UseIngredient("Кофе"))
            Console.WriteLine("Заваривание кофе...");
        else
        {
            Console.WriteLine("Нет кофе");
            product.AddProduct();
        }
    }

    protected override void Brew() 
    {
        if (product.UseIngredient("Сахар") && product.UseIngredient("Молоко"))
            Console.WriteLine("Добавление сахара и молока");
        else
        {
            Console.WriteLine("Нет сахара и лимона");
            product.AddProduct();
        }
    }
}

public class HotChocolate(Product product) : Beverage
{
    protected override void AddCondiments()
    {
        if (product.UseIngredient("Молоко"))
            Console.WriteLine("Добавление молока");
        else
        {
            Console.WriteLine("Нет молока");
            product.AddProduct();
        }
    }

    protected override void Brew()
    {
        if (product.UseIngredient("Шоколад"))
            Console.WriteLine("Заваривание горячего шоколада");
        else
        {
            Console.WriteLine("Нет шоколада");
            product.AddProduct();
        }
    }
}

#endregion

#region Класс Продукты

public class Product
{
    private readonly Dictionary<string, int> _ingredients = new()
    {
        { "Молоко", 3 },
        { "Шоколад", 3 },
        { "Лимон", 3 },
        { "Сахар", 3 }
    };
    
    public void ShowProducts()
    {
        Console.WriteLine("Показать все продукты: ");
        foreach (var keyValuePair in _ingredients)
            Console.WriteLine($"Название продукта: {keyValuePair.Key}, Количество: {keyValuePair.Value} шт");
    }

    public void AddProduct()
    {
        while (true)
        {
            Console.WriteLine("Добавить продукт");
            var product = ReadInput("Название продукта: ");
            int count;
            while (!int.TryParse(ReadInput("Количество продукта: "), out count) || count < 0)
                Console.WriteLine("Некорректное значение");

            if (_ingredients.ContainsKey(product))
                _ingredients[product] += count;
            
            _ingredients.Add(product, count);

            Console.WriteLine("Продукт добавлен!");
            
            var exite = ReadInput("Добавить новый продукт? (1 - Да, 0 - Нет): ");
            if (exite == "0")
                return;
        }
    }

    private bool HasIngredient(string name, int count = 1) => 
        _ingredients.ContainsKey(name) && _ingredients[name] >= count;

    public bool UseIngredient(string ingredient, int count = 1)
    {
        if (!HasIngredient(ingredient, count))
        {
            Console.WriteLine($"Недостаточно ингредиента: {ingredient}");
            return false;
        }

        _ingredients[ingredient] -= count;
        Console.WriteLine($"Использован ингредиент: {ingredient} ({count} шт)");
        return true;
    }

    private string ReadInput(string message)
    {
        Console.Write(message);
        while (true)
        {
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Введите корректные данные");
        }
    }
}

#endregion