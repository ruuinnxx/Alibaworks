int[] ints = [-253, 25, 52, 357, -568, 96, -47, 42, 45, -5];
PrintPositiveNumbers(ints);
return;

void PrintPositiveNumbers(int[] numbers)
{
    var positiveNumbers = numbers.Where(n => n > 0);

    foreach (var number in positiveNumbers)
        Console.WriteLine(number);
}