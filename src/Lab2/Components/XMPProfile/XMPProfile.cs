namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfile;

public class XMPProfile : IComponent
{
    public XMPProfile(string name, string timing, int frequency, int voltage)
    {
        new XMPFormatValidator().Validate(name, timing, frequency, voltage);

        Name = name;
        Frequency = frequency;
        Voltage = voltage;
        Timing = timing;
    }

    public string Name { get; }
    public string Timing { get; }

    public int Frequency { get; }

    public int Voltage { get; }
}