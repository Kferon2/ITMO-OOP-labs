using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;

public class PersonBuilder : IPersonBuilder
{
    private string? _name;
    private string? _surname;
    private long? _id;

    public IPersonBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPersonBuilder WithSurname(string surname)
    {
        _surname = surname;
        return this;
    }

    public IPersonBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public Person Build()
    {
        return new Person(
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _surname ?? throw new ArgumentNullException(nameof(_surname)));
    }
}