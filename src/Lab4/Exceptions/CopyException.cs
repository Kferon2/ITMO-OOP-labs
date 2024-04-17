using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class CopyException : ArgumentException
{
    public CopyException(string message)
        : base(message)
    {
    }

    public CopyException()
    {
    }

    public CopyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}