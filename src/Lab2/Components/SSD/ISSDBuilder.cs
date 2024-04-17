using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSD;

public interface ISSDBuilder
{
    ISSDBuilder WithName(string name);

    ISSDBuilder WithPciE(PciE? pciE);

    ISSDBuilder WithSata(Sata? sata);

    ISSDBuilder WithMemoryCapacity(int memoryCapacity);

    ISSDBuilder WithMaximalWorkSpeed(int maximalWorkSpeed);

    ISSDBuilder WithPowerConsumption(int powerConsumption);

    ISSDBuilder Direct(SSD component);

    SSD Build();
}