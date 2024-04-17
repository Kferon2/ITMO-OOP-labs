namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ValidationResult
{
    public ValidationResult(string comment, bool isValid)
    {
        Comment = comment;
        IsValid = isValid;
    }

    public bool IsValid { get; }

    public string Comment { get; }
}