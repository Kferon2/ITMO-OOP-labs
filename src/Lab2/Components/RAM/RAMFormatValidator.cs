using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.RAM;

public class RAMFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        int memoryCapacity,
        IList<JDEC> supportedJdecs,
        MotherBoardFormFactor formFactor,
        IList<XMPProfile.XMPProfile> xmpProfiles,
        int powerConsumption,
        DDR ddr)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden RAM name format");

        if (memoryCapacity < 0) throw new NegativeIntArgumentException("Memory capacity can't be negative");
        if (xmpProfiles == null) throw new ArgumentNullException(nameof(xmpProfiles));

        if (supportedJdecs == null) throw new ArgumentNullException(nameof(supportedJdecs));

        if (xmpProfiles.Any(xmpProfile => !supportedJdecs.All(n => n.Frequency < xmpProfile.Frequency)))
            throw new CompatibilityException("XMP and JDEC aren't compatible");

        if (powerConsumption < 0) throw new NegativeIntArgumentException("Power consumption can't be negative");

        if (ddr == null) throw new ArgumentNullException(nameof(ddr));

        if (formFactor == null) throw new ArgumentNullException(nameof(formFactor));

        return true;
    }
}