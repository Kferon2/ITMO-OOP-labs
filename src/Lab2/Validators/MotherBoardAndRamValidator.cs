using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherBoardAndRamValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Ram.FormFactor.Name == computer.MotherBoard.FormFactor.Name;
        string comment = string.Empty;
        if (!isValid) comment = "Different Form Factors";
        return new ValidationResult(comment, isValid);
    }
}