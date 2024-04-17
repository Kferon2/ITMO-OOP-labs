namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;

public interface IPersonBuilder
{
    IPersonBuilder WithName(string name);

    IPersonBuilder WithSurname(string surname);

    IPersonBuilder WithId(long id);

    Person Build();
}