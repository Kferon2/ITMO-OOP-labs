using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DirectoryExistException : ArgumentException
{
    public DirectoryExistException(string message)
        : base(message)
    {
    }

    public DirectoryExistException()
    {
    }

    public DirectoryExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}