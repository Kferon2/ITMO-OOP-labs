using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ExistException : ArgumentException
{
    public ExistException(string message)
        : base(message)
    {
    }

    public ExistException()
    {
    }

    public ExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}