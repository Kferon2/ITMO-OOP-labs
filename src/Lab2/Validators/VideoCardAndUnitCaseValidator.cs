using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class VideoCardAndUnitCaseValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int maxVideoCardLength =
            computer.VideoCards.Select(variableVideoCard => variableVideoCard.Length).Prepend(0).Max();
        int sumVideoCardHeight = computer.VideoCards.Sum(videoCard => videoCard.Height);

        bool isValid = maxVideoCardLength <= computer.Case.Length && sumVideoCardHeight <= computer.Case.Height;
        return !isValid ? new ValidationResult("VideoCard is too big for Case", isValid) : new ValidationResult(string.Empty, isValid);
    }
}