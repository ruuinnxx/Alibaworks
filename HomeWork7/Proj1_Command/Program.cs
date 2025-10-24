﻿#region Клиентксий код

var light = new Light();
var door = new Door();
var thermostat = new Thermostat();

var invoker = new Invoker();

// команды
var lightOn = new OnLightCommand(light);
var lightOff = new OffLightCommand(light);
var switchColor = new SwitchColorCommand(light);

var doorOpen = new OpenDoorCommand(door);
var doorClose = new CloseDoorCommand(door);

var increaseTemp = new IncreaseTempCommand(thermostat);
var decreaseTemp = new DecreaseTempCommand(thermostat);

// выполнение команд

invoker.ExecuteCommand(lightOff);
invoker.ExecuteCommand(doorOpen);
invoker.ExecuteCommand(increaseTemp);


Console.WriteLine("Отмена последних команд из стека по принципу LIFO");
invoker.UndoLastCommand();
invoker.UndoLastCommand();
invoker.UndoLastCommand();


#endregion

public interface ICommand
{
    void Execute();
    void Undo();
}

#region Пульт управления

public class Invoker
{
    private readonly Stack<ICommand> _history = new();
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_history.Count > 0)
        {
            var command = _history.Pop();
            command.Undo();
        }
        else
            Console.WriteLine("Нет команд для отмены");
    }
}

#endregion

#region Классы устройств

public class Light 
{
    public void On()
    {
        Console.WriteLine("Включить свет");
    }

    public void Off()
    {
        Console.WriteLine("Выключить свет");
    }

    public void SwitchColor()
    {
        Console.WriteLine("Переключить цвет");
    }
}

public class Door
{
    public void OpenDoor()
    {
        Console.WriteLine("Открыть дверь");
    }
    
    public void CloseDoor()
    {
        Console.WriteLine("Закрыть дверь");
    }}

public class Thermostat
{
    public void IncreaseTemp()
    {
        Console.WriteLine("Поднять температуру");
    }

    public void DecreaseTemp()
    {
        Console.WriteLine("Уменьшить температуру");
    }
}

#endregion

#region Конкретные команды

public class OnLightCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.On();
    }

    public void Undo()
    {
        light.Off();
    }
}

public class OffLightCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.Off();
    }

    public void Undo()
    {
        light.On();
    }
}

public class SwitchColorCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.SwitchColor();
    }

    public void Undo()
    {
        light.Off();
    }
}

public class OpenDoorCommand(Door door) : ICommand
{
    public void Execute()
    {
        door.OpenDoor();
    }

    public void Undo()
    {
        door.CloseDoor();
    }
}

public class CloseDoorCommand(Door door) : ICommand
{
    public void Execute()
    {
        door.CloseDoor();
    }

    public void Undo()
    {
        door.OpenDoor();
    }
}

public class IncreaseTempCommand(Thermostat thermostat) : ICommand
{
    public void Execute()
    {
        thermostat.IncreaseTemp();
    }

    public void Undo()
    {
        thermostat.DecreaseTemp();
    }
}

public class DecreaseTempCommand(Thermostat thermostat) : ICommand
{
    public void Execute()
    {
        thermostat.DecreaseTemp();
    }

    public void Undo()
    {
        thermostat.IncreaseTemp();
    }
}

#endregion