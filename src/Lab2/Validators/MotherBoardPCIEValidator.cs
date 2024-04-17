using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class MotherBoardPCIEValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.VideoCards.Any(n => n.PciE.Type != computer.MotherBoard.PciE.Type))
            return new ValidationResult("Out of PCI-E ports", false);

        int requiredPortsCount = computer.VideoCards.Sum(variableVideoCard => variableVideoCard.PciE.LinesCount);

        if (computer.Ssds.Any(n => n.PciE != null && n.PciE.Type != computer.MotherBoard.PciE.Type))
            return new ValidationResult("Out of PCI-E ports", false);

        requiredPortsCount += computer.Ssds.Where(variableSdd => variableSdd.PciE != null)
            .Sum(variableSdd => variableSdd.PciE?.LinesCount ?? 0);

        if (computer.WiFiAdapter != null && computer.WiFiAdapter.PciE.Type != computer.MotherBoard.PciE.Type)
        {
            return new ValidationResult("Out of PCI-E ports", false);
        }

        if (computer.WiFiAdapter != null) requiredPortsCount += computer.WiFiAdapter.PciE.LinesCount;

        bool isValid = requiredPortsCount <= computer.MotherBoard.PciE.LinesCount;
        string comment = string.Empty;
        if (!isValid) comment = "Out of PCI-E ports";
        return new ValidationResult(comment, isValid);
    }
}