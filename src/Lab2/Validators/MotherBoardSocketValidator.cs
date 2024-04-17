using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherBoardSocketValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int requiredPortsCount = 0;

        if (computer.Processor.Sockets.SocketType != computer.MotherBoard.Sockets.SocketType)
        {
            return new ValidationResult("Out of Sockets", false);
        }

        requiredPortsCount += computer.Processor.Sockets.SocketCount;

        if (computer.CoolingSystem.Sockets.SocketType != computer.MotherBoard.Sockets.SocketType)
        {
            return new ValidationResult("Out of Sockets", false);
        }

        requiredPortsCount += computer.CoolingSystem.Sockets.SocketCount;

        bool isValid = requiredPortsCount <= computer.MotherBoard.Sockets.SocketCount;
        string comment = string.Empty;
        if (!isValid) comment = "Out of Sockets";
        return new ValidationResult(comment, isValid);
    }
}