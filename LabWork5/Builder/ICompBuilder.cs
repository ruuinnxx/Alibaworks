namespace Project2_Builder;

public interface IComputerBuilder
{
    void SetCPU();
    void SetRAM();
    void SetStorage();
    void SetGPU();
    void SetOS();
    void SetCooling();
    void SetPowerSupply();
    Computer GetComputer();
}
