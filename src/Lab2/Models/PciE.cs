using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PciE
{
    public PciE(string type, int linesCount)
    {
        if (!new StringValidator().Validate(type)) throw new BadStringFormatException("Forbidden PCI-E name format");
        if (linesCount < 0) throw new NegativeIntArgumentException("Number of PCI-E lines can't be negative");

        Type = type;
        LinesCount = linesCount;
    }

    public string Type { get; }

    public int LinesCount { get; }
}