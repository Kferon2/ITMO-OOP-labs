using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileExistException : ArgumentException
{
    public FileExistException(string message)
        : base(message)
    {
    }

    public FileExistException()
    {
    }

    public FileExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}