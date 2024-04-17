using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.BIOS;

public class BIOSFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, string type, string version, IReadOnlyList<string> supportedProcessors)
    {
        if (new BIOSPossibleNames().Names.All(n => name != n))
            throw new BadStringFormatException("Forbidden BIOS name format");
        if (!_stringValidator.Validate(name)) throw new BadStringFormatException("Forbidden BIOS name format");
        if (!_stringValidator.Validate(type)) throw new BadStringFormatException("Forbidden BIOS type format");
        if (!_stringValidator.Validate(version)) throw new BadStringFormatException("Forbidden BIOS version format");
        if (!supportedProcessors.Aggregate(
                true,
                (current, variableProcessor) => current && _stringValidator.Validate(variableProcessor)))
            throw new BadStringFormatException("Forbidden supported Processor name format");
        return true;
    }
}