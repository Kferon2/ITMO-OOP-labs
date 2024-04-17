using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MotherBoardFormFactor
{
    private StringValidator _stringValidator = new();

    public MotherBoardFormFactor(string name, int length, int width, int height)
    {
        if (length < 0)
        {
            throw new ArgumentException("Length can't be negative", nameof(length));
        }

        if (width < 0)
        {
            throw new ArgumentException("Width be negative", nameof(width));
        }

        if (height < 0)
        {
            throw new ArgumentException("Height can't be negative", nameof(height));
        }

        if (!_stringValidator.Validate(name)) throw new BadStringFormatException("Forbidden motherboard name format");
        Name = name;
    }

    public string Name { get; }

    public int Length { get; }

    public int Width { get; }

    public int Height { get; }
}