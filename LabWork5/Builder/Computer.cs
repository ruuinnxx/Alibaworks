namespace Project2_Builder;

public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }
    public string OS { get; set; }
    public string Cooling { get; set; } // Тип охлаждения
    public string PowerSupply { get; set; } // Блок питания

    public override string ToString()
    {
        return $"Компьютер:\n" +
               $"CPU - {CPU}, RAM - {RAM}, Storage - {Storage}, GPU - {GPU}, OS - {OS},\n" +
               $"Cooling - {Cooling}, PowerSupply - {PowerSupply}";
    }
    
    public void Validate()
    {
        if (CPU.Contains("i9") && PowerSupply.Contains("450W"))
            throw new Exception("Мощный процессор требует более сильного блока питания!");
    
        if (GPU.Contains("RTX") && Cooling == "Air Cooling")
            throw new Exception("Игровая видеокарта требует жидкостного охлаждения!");
    }

}