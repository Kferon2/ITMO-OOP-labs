using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class PersonAddressee : IAddressee
{
    private Person _person;

    public PersonAddressee(Person person)
    {
        _person = person ?? throw new ArgumentNullException(nameof(person));
    }

    public void GetMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _person.Messages.Add(new PersonMessage(message));
    }
}