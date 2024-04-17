using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfile;

public class XMPProfileBuilder : IXmpProfileBuilder
{
    private string? _name;
    private string? _timing;
    private int? _frequency;
    private int? _voltage;

    public IXmpProfileBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IXmpProfileBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public IXmpProfileBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpProfileBuilder WithTiming(string timing)
    {
        _timing = timing;
        return this;
    }

    public IXmpProfileBuilder Direct(XMPProfile component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithFrequency(component.Frequency)
            .WithVoltage(component.Voltage)
            .WithTiming(component.Timing);
        return this;
    }

    public XMPProfile Build()
    {
        return new Components.XMPProfile.XMPProfile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _timing ?? throw new ArgumentNullException(nameof(_timing)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)),
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)));
    }
}