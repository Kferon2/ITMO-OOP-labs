using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class TDPValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Processor.TDP <= computer.CoolingSystem.TDP;
        return !isValid ? new ValidationResult("Not enough TDP", isValid) : new ValidationResult(string.Empty, isValid);
    }
}