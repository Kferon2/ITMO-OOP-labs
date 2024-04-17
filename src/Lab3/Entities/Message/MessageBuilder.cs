using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;

public class MessageBuilder : IMessageBuilder
{
    private string? _name;
    private string? _text;
    private int? _importanceLevel;

    public IMessageBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMessageBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public IMessageBuilder WithImportanceLevel(int level)
    {
        _importanceLevel = level;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _text ?? throw new ArgumentNullException(nameof(_text)),
            _importanceLevel ?? throw new ArgumentNullException(nameof(_importanceLevel)));
    }
}