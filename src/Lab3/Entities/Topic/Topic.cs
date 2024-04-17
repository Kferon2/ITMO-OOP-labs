using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;

public class Topic
{
    private readonly IAddressee _addresseeProxyFilter;

    public Topic(string name, IAddressee addressee)
    {
        new TopicFormatValidator().Validate(name);
        Name = name;
        _addresseeProxyFilter = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public string Name { get; }

    public void GetMessage(Message.Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _addresseeProxyFilter.GetMessage(message);
    }
}