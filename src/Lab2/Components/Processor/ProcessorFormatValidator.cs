using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Processor;

public class ProcessorFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        int coreFrequency,
        int coreCount,
        Sockets sockets,
        IReadOnlyCollection<int> supportedMemoryFrequency,
        int tdp,
        int powerConsumption)
    {
        if (!_stringValidator.Validate(name)) throw new BadStringFormatException("Forbidden Processor name format");
        if (coreFrequency < 0) throw new NegativeIntArgumentException("Core frequency can't be negative");
        if (coreCount < 0) throw new NegativeIntArgumentException("Core count can't be negative");
        if (sockets == null) throw new ArgumentNullException(nameof(sockets));
        if (supportedMemoryFrequency.Any(n => n < 0))
            throw new NegativeIntArgumentException("Memory frequency can't be negative");
        if (tdp < 0) throw new NegativeIntArgumentException("TDP can't be negative");
        if (powerConsumption < 0) throw new NegativeIntArgumentException("Power consumption can't be negative");
        return true;
    }
}