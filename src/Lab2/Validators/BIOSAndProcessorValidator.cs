using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class BIOSAndProcessorValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Bios == null ||
                       computer.Bios.SupportedProcessors.Any(variablProcessor =>
                           variablProcessor == computer.Processor.Name);
        string comment = string.Empty;
        if (!isValid) comment = "Processor isn't supported by BIOS";

        return new ValidationResult(comment, isValid);
    }
}