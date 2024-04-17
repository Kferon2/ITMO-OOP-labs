using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;

public class PowerUnitFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, int peakLoad)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden power unit name format");

        if (peakLoad < 0) throw new NegativeIntArgumentException("Peak load can't be negative");

        return true;
    }
}