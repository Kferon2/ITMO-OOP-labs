using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Sata
{
    private StringValidator _stringValidator = new();

    public Sata(string type, int portCount)
    {
        if (!_stringValidator.Validate(type)) throw new BadStringFormatException("Forbidden Sata name format");
        if (portCount < 0) throw new NegativeIntArgumentException("Number of Sata ports can't be negative");

        Type = type;
        PortCount = portCount;
    }

    public string Type { get; }

    public int PortCount { get; }
}