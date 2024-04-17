using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Filters;

public class ImportanceLevelFilter : IFilter
{
    public ImportanceLevelFilter(int importanceLevel)
    {
        if (importanceLevel < 0) throw new NegativeIntArgumentException("Importance level can't be negative");
        ImportanceLevel = importanceLevel;
    }

    public int ImportanceLevel { get; }

    public bool Filtrate(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        return message.ImportanceLevel <= ImportanceLevel;
    }
}