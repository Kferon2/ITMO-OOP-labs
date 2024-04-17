using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PowerConsumptionValidator : IValidator
{
    public ValidationResult Validate(Computer.Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int requiredPowerConsumption = 0;

        requiredPowerConsumption += computer.Processor.PowerConsumption;
        requiredPowerConsumption += computer.Ram.PowerConsumption;
        requiredPowerConsumption += computer.VideoCards.Sum(variableVideoCard => variableVideoCard.PowerConsumption);
        requiredPowerConsumption += computer.Hdds.Sum(variableHdd => variableHdd.PowerConsumption);
        requiredPowerConsumption += computer.Ssds.Sum(variableSdd => variableSdd.PowerConsumption);
        if (computer.WiFiAdapter != null) requiredPowerConsumption += computer.WiFiAdapter.PowerConsumption;
        bool isValid = requiredPowerConsumption <= computer.PowerUnit.PeakLoad;
        return !isValid ? new ValidationResult("Big Power Consumption", isValid) : new ValidationResult(string.Empty, isValid);
    }
}