using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class VideoCardValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Processor.BuiltInVideoCore || computer.VideoCards.Count != 0;
        return !isValid ? new ValidationResult("No required Videocard", isValid) : new ValidationResult(string.Empty, isValid);
    }
}