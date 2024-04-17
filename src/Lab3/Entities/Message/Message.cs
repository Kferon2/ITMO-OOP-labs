namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

public class Message
{
    public Message(string name, string text, int importanceLevel)
    {
        new MessageFormatValidator().Validate(name, text, importanceLevel);
        Name = name;
        Text = text;
        ImportanceLevel = importanceLevel;
    }

    public string Name { get; }

    public string Text { get; }

    public int ImportanceLevel { get; }
}