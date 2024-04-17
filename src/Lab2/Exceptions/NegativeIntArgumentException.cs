using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativeIntArgumentException : ArgumentException
{
    public NegativeIntArgumentException(string message)
        : base(message)
    {
    }

    public NegativeIntArgumentException()
    {
    }

    public NegativeIntArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}