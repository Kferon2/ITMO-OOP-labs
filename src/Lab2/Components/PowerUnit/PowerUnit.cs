namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;

public class PowerUnit : IComponent
{
    public PowerUnit(string name, int peakLoad)
    {
        new PowerUnitFormatValidator().Validate(name, peakLoad);
        Name = name;
        PeakLoad = peakLoad;
    }

    public string Name { get; }

    public int PeakLoad { get; }
}