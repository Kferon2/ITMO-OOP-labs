using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDD;

public class HDD : IComponent
{
    public HDD(string name, int memoryCapacity, int spindleSpeed, int powerConsumption, Sata sata)
    {
        new HDDFormatValidator().Validate(name, memoryCapacity, spindleSpeed, powerConsumption, sata);
        Name = name;
        MemoryCapacity = memoryCapacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
        Sata = sata;
    }

    public string Name { get; }

    public int MemoryCapacity { get; }

    public int SpindleSpeed { get; }

    public int PowerConsumption { get; }

    public Sata Sata { get; }
}