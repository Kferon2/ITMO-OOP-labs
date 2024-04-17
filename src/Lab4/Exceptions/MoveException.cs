using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class MoveException : ArgumentException
{
    public MoveException(string message)
        : base(message)
    {
    }

    public MoveException()
    {
    }

    public MoveException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}