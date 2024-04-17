using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ReadMessageException : ArgumentException
{
    public ReadMessageException(string message)
        : base(message)
    {
    }

    public ReadMessageException()
    {
    }

    public ReadMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}