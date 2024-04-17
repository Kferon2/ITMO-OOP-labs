namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfile;

public interface IXmpProfileBuilder
{
    IXmpProfileBuilder WithName(string name);

    IXmpProfileBuilder WithFrequency(int frequency);

    IXmpProfileBuilder WithVoltage(int voltage);

    IXmpProfileBuilder WithTiming(string timing);

    IXmpProfileBuilder Direct(XMPProfile component);

    XMPProfile Build();
}