using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class XMPAndMotherBoardValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        bool isValid = computer.Ram.XmpProfiles.Count == 0 || computer.MotherBoard.ChipSet.SupportXMP;
        return !isValid ? new ValidationResult("XMP doesn't supported by MotherBoard", isValid) : new ValidationResult(string.Empty, isValid);
    }
}