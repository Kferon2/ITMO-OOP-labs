using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeProxyLogger : IAddressee
{
    private IAddressee _addressee;

    public AddresseeProxyLogger(IAddressee addressee)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public int Counter { get; private set; }

    public void GetMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Counter++;
        new Logger().Log("Message with text: " + message.Text + "has been sent to: " + message.Name);
        _addressee.GetMessage(message);
    }
}