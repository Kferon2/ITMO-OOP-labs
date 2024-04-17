using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDD;

public interface IHDDBuilder
{
    IHDDBuilder WithName(string name);

    IHDDBuilder WithSpindleSpeed(int spindleSpeed);

    IHDDBuilder WithPowerConsumption(int powerConsumption);

    IHDDBuilder WithMemoryCapacity(int memoryCapacity);

    IHDDBuilder WithSata(Sata sata);

    IHDDBuilder Direct(HDD component);

    HDD Build();
}