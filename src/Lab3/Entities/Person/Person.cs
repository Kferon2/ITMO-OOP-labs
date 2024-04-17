using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;

public class Person
{
    public Person(long id, string name, string surname)
    {
        new PersonFormatValidator().Validate(id, name, surname);

        Id = id;
        Name = name;
        Surname = surname;
    }

    public Person(long id, string name, string surname, IList<PersonMessage> messages)
    {
        new PersonFormatValidator().Validate(id, name, surname, messages);

        Id = id;
        Name = name;
        Surname = surname;
        Messages = messages;
    }

    public long Id { get; }

    public string Name { get; }

    public string Surname { get; }

    public IList<PersonMessage> Messages { get; } = new List<PersonMessage>();

    public void ReadMessage(PersonMessage message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        message.ReadMessage();
    }

    public void ReadMessage(int index)
    {
        if (index < 0 || index + 1 > Messages.Count) throw new OutOfRangeIndexException("There is no message");
        if (Messages[index].IsRead) throw new ReadMessageException("Message has already been read");
        Messages[index].ReadMessage();
    }
}