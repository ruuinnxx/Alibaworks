int[] ints = [52, 35, 7, 37, 0, 346, 36, 1, 357, 375];
ProcessNumbers(ints);
return;

void ProcessNumbers(int[]? numbers)
{
    if (numbers is not { Length: > 0 }) return;
    foreach (var number in numbers)
        if (number > 0) Console.WriteLine(number);
}
