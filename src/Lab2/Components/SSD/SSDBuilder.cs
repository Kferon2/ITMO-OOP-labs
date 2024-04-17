using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSD;

public class SSDBuilder : ISSDBuilder
{
    private string? _name;
    private PciE? _pciE;
    private Sata? _sata;
    private int? _memoryCapacity;
    private int? _maximalWorkSpeed;
    private int? _powerConsumption;

    public ISSDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISSDBuilder WithPciE(PciE? pciE)
    {
        _pciE = pciE;
        return this;
    }

    public ISSDBuilder WithSata(Sata? sata)
    {
        _sata = sata;
        return this;
    }

    public ISSDBuilder WithMemoryCapacity(int memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
        return this;
    }

    public ISSDBuilder WithMaximalWorkSpeed(int maximalWorkSpeed)
    {
        _maximalWorkSpeed = maximalWorkSpeed;
        return this;
    }

    public ISSDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISSDBuilder Direct(SSD component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithPciE(component.PciE)
            .WithSata(component.Sata)
            .WithMemoryCapacity(component.MemoryCapacity)
            .WithMaximalWorkSpeed(component.MaximalWorkSpeed)
            .WithPowerConsumption(component.PowerConsumption);
        return this;
    }

    public Components.SSD.SSD Build()
    {
        return new Components.SSD.SSD(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _pciE,
            _sata,
            _memoryCapacity ?? throw new ArgumentNullException(nameof(_memoryCapacity)),
            _maximalWorkSpeed ?? throw new ArgumentNullException(nameof(_maximalWorkSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}