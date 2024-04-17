namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder WithName(string name);

    IPowerUnitBuilder WithPeakLoad(int peakLoad);

    IPowerUnitBuilder Direct(PowerUnit component);

    PowerUnit Build();
}