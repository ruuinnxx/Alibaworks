var workers = new List<Worker>
{
    new Worker("Ержан", 11, "Инженер", 1500, 7),
    new Worker("Светлана", 12, "Бухгалтер", 1200, 6),
    new Worker("Нурлан", 13, "Оператор", 1000, 9)
};
var managers = new List<Manager>
{
    new Manager("Алексей", 21, "Главный Менеджер", 300000, 50000),
    new Manager("Жанна", 22, "Менеджер отдела продаж", 220000, null)
};

foreach (var worker in workers)
    Console.WriteLine(
        $"Сотрудник: {worker.Name}, Id: {worker.IdEmployee}, Должность: {worker.Post}, Ставка за час: {worker.HourlyRate} тг, Количество часов: {worker.NumberOfHours}, Расчет зарплаты за день: {worker.SalaryCalculation()} тг");

Console.WriteLine();

foreach (var manager in managers)
{
    Console.WriteLine(manager.Bonus != null
        ? $"Сотрудник: {manager.Name}, Id: {manager.IdEmployee}, Должность: {manager.Post}, Фиксированная зарплата: {manager.FixedSalary} тг, Премия: {manager.Bonus} тг, Расчет зарплаты за день: {manager.SalaryCalculation()} тг"
        : $"Сотрудник: {manager.Name}, Id: {manager.IdEmployee}, Должность: {manager.Post}, Фиксированная зарплата: {manager.FixedSalary} тг, Расчет зарплаты за день: {manager.SalaryCalculation()} тг");
}


public abstract class Employee(string name, int idEmployee, string post)
{
    public string Name { get; } = name;
    public int IdEmployee { get; } = idEmployee;
    public string Post { get; } = post;

    public abstract decimal? SalaryCalculation();
}

internal class Worker(string name, int idEmployee, string post, decimal hourlyRate, int numberOfHours)
    : Employee(name, idEmployee, post)
{
    public decimal HourlyRate { get; } = hourlyRate;
    public int NumberOfHours { get; } = numberOfHours;

    public override decimal? SalaryCalculation() => HourlyRate * NumberOfHours;
}

internal class Manager(string name, int idEmployee, string post, decimal fixedSalary, decimal? bonus)
    : Employee(name, idEmployee, post)
{
    public decimal FixedSalary { get; } = fixedSalary;
    public decimal? Bonus { get; } = bonus;

    public override decimal? SalaryCalculation()
    {
        return FixedSalary + (Bonus ?? 0);
    }
}
