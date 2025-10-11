namespace Project2_Builder;

public class ServerComputerBuilder : IComputerBuilder
{
    private readonly Computer _computer = new ();

    public void SetCPU() => _computer.CPU = "AMD EPYC";
    public void SetRAM() => _computer.RAM = "128GB ECC";
    public void SetStorage() => _computer.Storage = "4TB SSD RAID";
    public void SetGPU() => _computer.GPU = "Basic (No GPU)";
    public void SetOS() => _computer.OS = "Linux Server";
    public void SetCooling() => _computer.Cooling = "Advanced Air Cooling";
    public void SetPowerSupply() => _computer.PowerSupply = "1200W Platinum";

    public Computer GetComputer() => _computer;
}
