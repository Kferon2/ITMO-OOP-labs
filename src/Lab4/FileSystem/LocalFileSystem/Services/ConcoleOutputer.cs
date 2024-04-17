using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.LocalFileSystem.Services;

public class ConcoleOutputer : IOutputer
{
    public ConcoleOutputer(ITextFormatter formatter)
    {
        Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public ITextFormatter Formatter { get; }

    public void Write(string data)
    {
        Console.WriteLine(data);
    }
}