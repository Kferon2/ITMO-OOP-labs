using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class OutOfRangeIndexException : ArgumentException
{
    public OutOfRangeIndexException(string message)
        : base(message)
    {
    }

    public OutOfRangeIndexException()
    {
    }

    public OutOfRangeIndexException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}