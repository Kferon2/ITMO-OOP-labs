using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;

public class BIOS : IComponent
{
    public BIOS(string name, string type, string version, IReadOnlyList<string> supportedProcessors)
    {
        new BIOSFormatValidator().Validate(
            name,
            type,
            version,
            supportedProcessors);

        Name = name;
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Name { get; }

    public string Type { get; }

    public string Version { get; }

    public IReadOnlyList<string> SupportedProcessors { get; }
}