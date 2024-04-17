namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class StringValidator
{
    public bool Validate(string argument)
    {
        return !string.IsNullOrWhiteSpace(argument);
    }
}