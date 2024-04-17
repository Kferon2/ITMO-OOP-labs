using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MemoryValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Hdds.Count != 0 || computer.Ssds.Count != 0;
        string comment = string.Empty;
        if (!isValid) comment = "There is no memory module";
        return new ValidationResult(comment, isValid);
    }
}