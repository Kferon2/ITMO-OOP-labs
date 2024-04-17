using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCard;

public class VideoCardFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        int height,
        int length,
        int videoMemoryAmount,
        PciE pciE,
        int chipFrequency,
        int powerConsumption)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden video card name format");

        if (videoMemoryAmount < 0)
            throw new NegativeIntArgumentException("Video memory amount can't be negative");

        if (chipFrequency < 0)
            throw new NegativeIntArgumentException("Chip frequency can't be negative");

        if (length < 0)
            throw new NegativeIntArgumentException("Lenght can't be negative");
        if (powerConsumption < 0)
            throw new NegativeIntArgumentException("Power consumption can't be negative");
        if (height < 0)
            throw new NegativeIntArgumentException("Height can't be negative");

        if (pciE == null) throw new ArgumentNullException(nameof(pciE));

        return true;
    }
}