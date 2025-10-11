﻿// Создаем офисный компьютер

using Project2_Builder;
using Project2_Builder.КонкректныеСтроители;

// Офисный ПК
IComputerBuilder officeBuilder = new OfficeComputerBuilder();
var director = new ComputerDirector(officeBuilder);
director.ConstructComputer();
var officeComputer = director.GetComputer();
officeComputer.Validate();
Console.WriteLine(officeComputer);

// Игровой ПК
IComputerBuilder gamingBuilder = new GamingComputerBuilder();
director = new ComputerDirector(gamingBuilder);
director.ConstructComputer();
var gamingComputer = director.GetComputer();
gamingComputer.Validate();
Console.WriteLine(gamingComputer);

// Сервер
IComputerBuilder serverBuilder = new ServerComputerBuilder();
director = new ComputerDirector(serverBuilder);
director.ConstructComputer();
var serverComputer = director.GetComputer();
serverComputer.Validate();
Console.WriteLine(serverComputer);