using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherBoardAndUnitCaseValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Case.SupportedFormFactors.Any(motherBoardFormFactor =>
            motherBoardFormFactor.Name == computer.MotherBoard.FormFactor.Name);
        string comment = string.Empty;
        if (!isValid) comment = "Different Form Factors";
        return new ValidationResult(comment, isValid);
    }
}