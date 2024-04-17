using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;

public class PersonFormatValidator
{
    private readonly StringValidator _stringValidator = new StringValidator();
    public bool Validate(long id, string name, string surname)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Bad person name format");

        if (!_stringValidator.Validate(surname))
            throw new BadStringFormatException("Bad person surname name format");

        if (id < 0) throw new NegativeIntArgumentException("Person id can't be negative");

        return true;
    }

    public bool Validate(long id, string name, string surname, IList<PersonMessage> messages)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Bad person name format");

        if (!_stringValidator.Validate(surname))
            throw new BadStringFormatException("Bad person surname name format");

        if (id < 0) throw new NegativeIntArgumentException("Person id can't be negative");

        if (messages == null) throw new ArgumentNullException(nameof(messages));

        return true;
    }
}