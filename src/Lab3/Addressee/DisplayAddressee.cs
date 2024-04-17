using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    private IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));
    }

    public void GetMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _display.ShowText(message.Text);
    }
}