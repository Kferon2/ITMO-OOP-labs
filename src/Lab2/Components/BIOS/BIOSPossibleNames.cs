using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;

public record BIOSPossibleNames()
{
    public IEnumerable<string> Names { get; } =
        new List<string>() { "BIOS", "AMI", "UEFI", "AWARD", "Phoenix", "Super", "Mega" };
}