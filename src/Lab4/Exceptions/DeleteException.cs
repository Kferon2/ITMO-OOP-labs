using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DeleteException : ArgumentException
{
    public DeleteException(string message)
        : base(message)
    {
    }

    public DeleteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DeleteException()
    {
    }
}