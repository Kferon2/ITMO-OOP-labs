using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class PersonMessage
{
    public PersonMessage(Message message, bool read = false)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        IsRead = read;
    }

    public Message Message { get; }

    public bool IsRead { get; private set; }

    public void ReadMessage()
    {
        IsRead = true;
    }
}