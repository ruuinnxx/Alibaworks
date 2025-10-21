﻿ControlSmartHouse();
return;

void ControlSmartHouse()
{
    while (true)
    {
        Console.WriteLine(">>> Управление умным домом <<<");
        var device = GetDevice();
        if (device == null!)
        {
            Console.WriteLine("Выход из программы");
            return;
        }

        GetCommand(device);
    }
}

SmartDevice GetDevice()
{
    var factories = new Dictionary<string, (string name, DeviceFactory factory)>
    {
        { "1", ("Компьютер", new ComputerFactory()) },
        { "2", ("Радио", new RadioFactory()) },
        { "3", ("Отопление", new HeatingFactory()) },
    };
    
    while (true)
    {
        Console.WriteLine("Список устройств:");
        foreach (var keyValue in factories)
        {
            Console.WriteLine($"{keyValue.Key} - {keyValue.Value.name}");
        }

        var device = ReadInput("Выберите устройство (0 - выйти): ");

        if (device == "0")
            return null!;
        
        if (factories.TryGetValue(device, out var factory))
        {
            Console.WriteLine($"Создан: {factory}");
            return factory.factory.CreateDevice();
        }

        Console.WriteLine("Выберите корректное устройство");
    }
}
void GetCommand(SmartDevice device)
{
    ICommand? onCommand = device switch
    {
        Computer => new ComputerOnCommand(device),
        Radio => new RadioOnCommand(device),
        Heating => new HeatingOnCommand(device),
        _ => null
    };

    ICommand? offCommand = device switch
    {
        Computer => new ComputerOffCommand(device),
        Radio => new RadioOffCommand(device),
        Heating => new HeatingOffCommand(device),
        _ => null
    };
    
    var macroCommand = new MacroCommand([
        onCommand!,
        offCommand!
    ]);

    var remote = new RemoteControl();

    remote.SetCommand(onCommand!, offCommand!);


    while (true)
    {
        var command = ReadInput("Выберите команду: " +
                                "\n1-Включить " +
                                "\n2-Выключить " +
                                "\n3-Отменить" +
                                "\n4-Включить и выключить устройство" +
                                "\n0-Выход");

        switch (command)
        {
            case "1":
                remote.PressOnButton();
                break;
            case "2":
                remote.PressOffButton();
                break;
            case "3":
                remote.PressUndoButton();
                break;
            case "4":
                macroCommand.Execute();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Введите корректную команду");
                break;
        }
    }
}
string ReadInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            return input;
        Console.WriteLine("Введите корректные данные");
    }
}


#region Интерфейс

public interface ICommand
{
    public void Execute();
    public void Undo();
}

#endregion

#region Классы устройств

public abstract class SmartDevice
{
    public abstract void On();
    public abstract void Off();
}

public abstract class DeviceFactory
{
    public abstract SmartDevice CreateDevice();
}

public class Computer : SmartDevice
{
    public override void On()
    {
        Console.WriteLine("Включение компьютера");
    }

    public override void Off()
    {
        Console.WriteLine("Выключение компьютера");
    }
}

public class ComputerFactory : DeviceFactory
{
    public override SmartDevice CreateDevice()
    {
        return new Computer();
    }
}

public class Radio : SmartDevice
{
    public override void On()
    {
        Console.WriteLine("Включение радио");
    }

    public override void Off()
    {
        Console.WriteLine("Выключение радио");
    }
}

public class RadioFactory : DeviceFactory
{
    public override SmartDevice CreateDevice()
    {
        return new Radio();
    }
}

public class Heating : SmartDevice
{
    public override void On()
    {
        Console.WriteLine("Включение отопления");
    }

    public override void Off()
    {
        Console.WriteLine("Выключение отопления");
    }
}

public class HeatingFactory : DeviceFactory
{
    public override SmartDevice CreateDevice()
    {
        return new Heating();
    }
}

#endregion

#region Классы команды

public class ComputerOnCommand(SmartDevice computer) : ICommand
{
    public void Execute()
    {
        computer.On();
    }

    public void Undo()
    {
        computer.Off();
    }
}

public class ComputerOffCommand(SmartDevice computer) : ICommand
{
    public void Execute()
    {
        computer.Off();
    }

    public void Undo()
    {
        computer.On();
    }
}

public class RadioOnCommand(SmartDevice radio) : ICommand
{
    public void Execute()
    {
        radio.On();
    }

    public void Undo()
    {
        radio.Off();
    }
}

public class RadioOffCommand(SmartDevice radio) : ICommand
{
    public void Execute()
    {
        radio.Off();
    }

    public void Undo()
    {
        radio.On();
    }
}

public class HeatingOnCommand(SmartDevice heating) : ICommand
{
    public void Execute()
    {
        heating.On();
    }

    public void Undo()
    {
        heating.Off();
    }
}

public class HeatingOffCommand(SmartDevice heating) : ICommand
{
    public void Execute()
    {
        heating.Off();
    }

    public void Undo()
    {
        heating.On();
    }
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

#region Пульт управления

public class RemoteControl
{
    private ICommand? _onCommand;
    private ICommand? _offCommand;

    public void SetCommand(ICommand? on, ICommand? off)
    {
        _onCommand = on;
        _offCommand = off;
    }

    public void PressOnButton()
    {
        _onCommand!.Execute();
    }

    public void PressOffButton()
    {
        _offCommand!.Execute();
    }

    public void PressUndoButton()
    {
        _onCommand!.Undo();
    }
}

#endregion