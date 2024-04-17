using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void Log(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}