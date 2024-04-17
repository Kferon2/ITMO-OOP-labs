using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class XMPAndProcessorValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Ram.XmpProfiles.Count == 0) return new ValidationResult(string.Empty, true);

        bool isValid = computer.Ram.XmpProfiles.Any(xmpProfile =>
            computer.Processor.SupportedMemoryFrequency.Any(frequency => xmpProfile.Frequency == frequency));
        return !isValid ? new ValidationResult("XMP isn't supported by Processor", isValid) : new ValidationResult(string.Empty, isValid);
    }
}