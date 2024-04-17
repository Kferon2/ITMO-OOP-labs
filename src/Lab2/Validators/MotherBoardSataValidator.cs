using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherBoardSataValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Ssds.Any(n => n.Sata != null && n.Sata.Type != computer.MotherBoard.Sata.Type))
            return new ValidationResult("Out of Sata ports", false);

        int requiredPortsCount = computer.Ssds.Where(variableSdd => variableSdd.Sata != null)
            .Sum(variableSdd => variableSdd.Sata?.PortCount ?? 0);

        if (computer.Hdds.Any(n => n.Sata.Type != computer.MotherBoard.Sata.Type))
            return new ValidationResult("Out of Sata ports", false);
        requiredPortsCount += computer.Hdds.Sum(variableHdd => variableHdd.Sata.PortCount);

        bool isValid = requiredPortsCount <= computer.MotherBoard.Sata.PortCount;
        string comment = string.Empty;
        if (!isValid) comment = "Out of PCI-E ports";
        return new ValidationResult(comment, isValid);
    }
}