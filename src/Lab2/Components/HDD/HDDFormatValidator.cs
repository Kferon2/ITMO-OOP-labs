using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.HDD;

public class HDDFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, int memoryCapacity, int spindleSpeed, int powerConsumption, Sata sata)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden HDD name format");

        if (memoryCapacity < 0) throw new NegativeIntArgumentException("Memory capacity can't be negative");

        if (spindleSpeed < 0) throw new NegativeIntArgumentException("Spindle speed can't be negative");

        if (powerConsumption < 0) throw new NegativeIntArgumentException("Power consumption can't be negative");

        if (sata == null) throw new ArgumentNullException(nameof(sata));

        return true;
    }
}