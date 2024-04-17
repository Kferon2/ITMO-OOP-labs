using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SystemUnitCase;

public class SystemUnitCaseFormatValidator
{
    private StringValidator _stringValidator = new();

    public bool Validate(
        string name,
        int maximalVideoCardHeight,
        int maximalVideoCardLength,
        IReadOnlyList<MotherBoardFormFactor> supportedFormFactors,
        int length,
        int height,
        int width)
    {
        if (!_stringValidator.Validate(name))
            throw new BadStringFormatException("Forbidden case name format");

        if (maximalVideoCardHeight < 0)
            throw new NegativeIntArgumentException("Maximal video card height can't be negative");

        if (maximalVideoCardLength < 0)
            throw new NegativeIntArgumentException("Maximal video card length can't be negative");

        if (length < 0)
            throw new NegativeIntArgumentException("Lenght can't be negative");
        if (width < 0)
            throw new NegativeIntArgumentException("Width can't be negative");
        if (height < 0)
            throw new NegativeIntArgumentException("Height can't be negative");

        if (supportedFormFactors == null) throw new ArgumentNullException(nameof(supportedFormFactors));

        if (supportedFormFactors.Any(n => n.Height > height || n.Length > length || n.Width > width))
            throw new CompatibilityException("Motherboard factor and case aren't compatible");

        return true;
    }
}