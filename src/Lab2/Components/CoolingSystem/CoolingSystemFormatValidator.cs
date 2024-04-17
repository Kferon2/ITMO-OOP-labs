using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolingSystem;

public class CoolingSystemFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(string name, int width, int height, int length, Sockets sockets, int tdp)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden Cooling System name format");

        if (width < 0) throw new NegativeIntArgumentException("Width can't be negative");

        if (length < 0) throw new NegativeIntArgumentException("Length can't be negative");

        if (height < 0) throw new NegativeIntArgumentException("Height can't be negative");

        if (tdp < 0) throw new NegativeIntArgumentException("TDP can't be negative");

        if (sockets == null) throw new ArgumentNullException(nameof(sockets));

        return true;
    }
}