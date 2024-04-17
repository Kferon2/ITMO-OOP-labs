using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfile;

public class XMPFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, string timing, int frequency, int voltage)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden SSD name format");

        if (!_stringValidator.Validate(timing))
            throw new BadStringFormatException("Forbidden timing format");

        if (frequency < 0) throw new NegativeIntArgumentException("Frequency capacity can't be negative");

        if (voltage < 0) throw new NegativeIntArgumentException("Voltage speed can't be negative");

        return true;
    }
}