using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private string? _name;
    private int? _peakLoad;

    public IPowerUnitBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPowerUnitBuilder WithPeakLoad(int peakLoad)
    {
        _peakLoad = peakLoad;
        return this;
    }

    public IPowerUnitBuilder Direct(PowerUnit component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithPeakLoad(component.PeakLoad);
        return this;
    }

    public PowerUnit Build()
    {
        return new Components.PowerUnit.PowerUnit(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}