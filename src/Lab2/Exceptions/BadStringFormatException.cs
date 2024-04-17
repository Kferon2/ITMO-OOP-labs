using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BadStringFormatException : ArgumentException
{
    public BadStringFormatException(string message)
        : base(message)
    {
    }

    public BadStringFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BadStringFormatException()
    {
    }
}