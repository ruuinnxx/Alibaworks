namespace Project2_Builder;

public class ComputerDirector(IComputerBuilder builder)
{
    public void ConstructComputer()
    {
        builder.SetCPU();
        builder.SetRAM();
        builder.SetStorage();
        builder.SetGPU();
        builder.SetOS();
        builder.SetCooling();
        builder.SetPowerSupply();
    }

    public Computer GetComputer() => builder.GetComputer();
}
