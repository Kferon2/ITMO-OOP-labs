using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDD;

public class HDDBuilder : IHDDBuilder
{
    private string? _name;
    private int? _spindleSpeed;
    private int? _memoryCapacity;
    private int? _powerConsumption;
    private Sata? _sata;

    public IHDDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IHDDBuilder WithSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHDDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHDDBuilder WithMemoryCapacity(int memoryCapacity)
    {
        _memoryCapacity = memoryCapacity;
        return this;
    }

    public IHDDBuilder WithSata(Sata sata)
    {
        _sata = sata;
        return this;
    }

    public IHDDBuilder Direct(HDD component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithPowerConsumption(component.PowerConsumption)
            .WithMemoryCapacity(component.MemoryCapacity)
            .WithSpindleSpeed(component.SpindleSpeed)
            .WithSata(component.Sata);
        return this;
    }

    public HDD Build()
    {
        return new Components.HDD.HDD(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _memoryCapacity ?? throw new ArgumentNullException(nameof(_memoryCapacity)),
            _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _sata ?? throw new ArgumentNullException(nameof(_sata)));
    }
}