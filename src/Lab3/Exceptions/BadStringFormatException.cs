using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class BadStringFormatException : ArgumentException
{
    public BadStringFormatException(string message)
        : base(message)
    {
    }

    public BadStringFormatException()
    {
    }

    public BadStringFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}