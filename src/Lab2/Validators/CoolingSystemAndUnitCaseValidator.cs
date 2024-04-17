using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CoolingSystemAndUnitCaseValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Case.Height >= computer.CoolingSystem.Height &&
                       computer.Case.Width >= computer.CoolingSystem.Width &&
                       computer.Case.Length >= computer.CoolingSystem.Height;
        string comment = string.Empty;
        if (!isValid) comment = "Cooling System doesn't fit into Case";
        return new ValidationResult(comment, isValid);
    }
}