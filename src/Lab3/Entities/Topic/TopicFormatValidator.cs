using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;

public class TopicFormatValidator
{
    private readonly StringValidator _stringValidator = new StringValidator();
    public bool Validate(string name)
    {
        if (!_stringValidator.Validate(name)) throw new BadStringFormatException("Bad Topic name format ");
        return true;
    }
}