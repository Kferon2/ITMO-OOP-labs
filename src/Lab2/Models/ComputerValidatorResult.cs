using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerValidatorResult
{
    public ComputerValidatorResult(IReadOnlyCollection<string> comments, bool isValid)
    {
        Comments = comments;
        IsValid = isValid;
    }

    public bool IsValid { get; }

    public IReadOnlyCollection<string> Comments { get; }
}