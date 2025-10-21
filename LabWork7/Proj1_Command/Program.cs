﻿#region Клиентский код

var livingRoomLight = new Light();
var tv = new Television();
var airConditioner = new AirConditioner();

var lightOn = new LightOnCommand(livingRoomLight);
var lightOff = new LightOffCommand(livingRoomLight);

var tvOn = new TvOnCommand(tv);
var tvOff = new TvOffCommand(tv);

var airOn = new AirOnCommand(airConditioner);
var airOff = new AirOffCommand(airConditioner);
var airEconomyMode = new AirEconomyMode(airConditioner);

var remote = new RemoteControl();

remote.SetCommands(lightOn, lightOff);
Console.WriteLine("Управление светом");
remote.PressOnButton();
remote.PressOffButton();
remote.PressUndoButton();

Console.WriteLine();

remote.SetCommands(tvOn, tvOff);
Console.WriteLine("Управление телевизором");
remote.PressOnButton();
remote.PressOffButton();
remote.PressUndoButton();

Console.WriteLine();

remote.SetCommands(airOn, airOff);
Console.WriteLine("Управление кондиционером");
remote.PressOnButton();
remote.PressOffButton();
remote.PressUndoButton();

Console.WriteLine("\nВключить все устройтва");
var macro = new MacroCommand([lightOn, tvOn, airOn]);
macro.Execute();
macro.Undo();

Console.WriteLine();

airOn.Execute();
airEconomyMode.Execute();
remote.PressUndoButton();

#endregion

#region Интерфейс для команды

public interface ICommand
{
    void Execute();
    void Undo();
}

#endregion

#region Конкретные команды

public class LightOnCommand(Light light) : ICommand
{
    public void Execute() =>
        light.On();

    public void Undo() =>
        light.Off();
}

public class LightOffCommand(Light light) : ICommand
{
    public void Execute() =>
        light.Off();

    public void Undo() =>
        light.On();
}


public class TvOnCommand(Television tv) : ICommand
{
    public void Execute() =>
        tv.On();

    public void Undo() =>
        tv.Off();
}

public class TvOffCommand(Television tv) : ICommand
{
    public void Execute() =>
        tv.Off();

    public void Undo() =>
        tv.On();
}


public class AirOnCommand(AirConditioner airConditioner) : ICommand
{
    public void Execute() =>
        airConditioner.On();

    public void Undo() =>
        airConditioner.Off();
}

public class AirOffCommand(AirConditioner airConditioner) : ICommand
{
    public void Execute() =>
        airConditioner.Off();

    public void Undo() =>
        airConditioner.On();
}

public class AirEconomyMode(AirConditioner airConditioner) : ICommand
{
    public void Execute() =>
        airConditioner.EconomyMode();

    public void Undo() =>
        airConditioner.On();
}

public class MacroCommand(List<ICommand> commands) : ICommand
{
    public void Execute()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        foreach (var command in commands)
        {
            command.Undo();
        }
    }
}

#endregion

#region Коенкретные устройства

public class Light
{
    public void On() =>
        Console.WriteLine("Свет включен");

    public void Off() =>
        Console.WriteLine("Свет выключен");
}

public class Television
{
    public void On() =>
        Console.WriteLine("Телевизор включен");

    public void Off() =>
        Console.WriteLine("Телевизор выключен");
}

public class AirConditioner
{
    public void On() =>
        Console.WriteLine("Кондиционер включен");

    public void Off() =>
        Console.WriteLine("Кондиционер выключен");
    
    public void EconomyMode() =>
        Console.WriteLine("Режим экономии энергии кондиционера");
}

#endregion

#region Пульт управления

public class RemoteControl
{
    private ICommand _onCommand = null!;
    private ICommand _offCommand = null!;

    public void SetCommands(ICommand onCommand, ICommand offCommand)
    {
        _onCommand = onCommand;
        _offCommand = offCommand;
    }

    public void PressOnButton()
    {
        _onCommand.Execute();
    }
    
    public void PressOffButton()
    {
        _offCommand.Execute();
    }
    
    public void PressUndoButton()
    {
        _onCommand.Undo();
    }
}

#endregion