using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class RenameException : ArgumentException
{
    public RenameException(string message)
        : base(message)
    {
    }

    public RenameException()
    {
    }

    public RenameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}