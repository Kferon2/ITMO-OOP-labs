using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SSD;

public class SSDFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        PciE? pciE,
        Sata? sata,
        int memoryCapacity,
        int maximalWorkSpeed,
        int powerConsumption)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden SSD name format");

        if (memoryCapacity < 0) throw new NegativeIntArgumentException("Memory capacity can't be negative");

        if (maximalWorkSpeed < 0) throw new NegativeIntArgumentException("Work speed can't be negative");

        if (powerConsumption < 0) throw new NegativeIntArgumentException("Power consumption can't be negative");

        if (sata == null && pciE == null)
            throw new ArgumentNullException(nameof(sata), "There must be at least one type of connection");

        return true;
    }
}