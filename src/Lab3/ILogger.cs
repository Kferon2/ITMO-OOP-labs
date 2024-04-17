using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface ILogger
{
    void Log(string message);

    void Log(string message, ConsoleColor color);
}