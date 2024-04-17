using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSD;

public class SSD : IComponent
{
    public SSD(string name, PciE? pciE, Sata? sata, int memoryCapacity, int maximalWorkSpeed, int powerConsumption)
    {
        new SSDFormatValidator().Validate(
            name,
            pciE,
            sata,
            memoryCapacity,
            maximalWorkSpeed,
            powerConsumption);

        Name = name;
        PciE = pciE;
        Sata = sata;
        MemoryCapacity = memoryCapacity;
        MaximalWorkSpeed = maximalWorkSpeed;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }

    public PciE? PciE { get; }

    public Sata? Sata { get; }

    public int MemoryCapacity { get; }

    public int MaximalWorkSpeed { get; }

    public int PowerConsumption { get; }
}