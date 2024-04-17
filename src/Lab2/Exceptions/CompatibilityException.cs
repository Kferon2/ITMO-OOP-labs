using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CompatibilityException : ArgumentException
{
    public CompatibilityException(string message)
        : base(message)
    {
    }

    public CompatibilityException()
    {
    }

    public CompatibilityException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}