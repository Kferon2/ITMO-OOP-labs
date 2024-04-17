namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

public interface IMessageBuilder
{
    IMessageBuilder WithName(string name);

    IMessageBuilder WithText(string text);

    IMessageBuilder WithImportanceLevel(int level);

    Message Build();
}