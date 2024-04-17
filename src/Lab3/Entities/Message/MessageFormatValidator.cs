using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

public class MessageFormatValidator
{
    private readonly StringValidator _stringValidator = new StringValidator();
    public bool Validate(string name, string text, int level)
    {
        if (!_stringValidator.Validate(name)) throw new BadStringFormatException("Bad message name format");
        if (!_stringValidator.Validate(text)) throw new BadStringFormatException("Bad text format");
        if (level < 0) throw new NegativeIntArgumentException("Importance level can't be negative");
        return true;
    }
}