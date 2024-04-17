namespace Itmo.ObjectOrientedProgramming.Lab3.Validators;

public class StringValidator
{
    public bool Validate(string argument)
    {
        return !string.IsNullOrWhiteSpace(argument);
    }
}