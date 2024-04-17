using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Sockets
{
    public Sockets(string socketType, int socketCount)
    {
        if (socketCount < 0) throw new NegativeIntArgumentException("Number of sockets can't be negative");

        if (new SocketPossibleNames().Names.All(n => socketType != n))
            throw new BadStringFormatException("Forbidden socket name format");

        SocketType = socketType;
        SocketCount = socketCount;
    }

    public string SocketType { get; }

    public int SocketCount { get; }
}