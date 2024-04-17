using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class Messenger : IMessenger
{
    public void WriteText(string text)
    {
        if (!new StringValidator().Validate(text)) throw new BadStringFormatException();
        new Logger().Log("Telegram: " + text);
    }
}