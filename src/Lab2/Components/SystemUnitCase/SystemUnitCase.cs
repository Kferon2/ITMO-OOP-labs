using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SystemUnitCase;

public class SystemUnitCase : IComponent
{
    public SystemUnitCase(
        string name,
        int maximalVideoCardHeight,
        int maximalVideoCardLength,
        IReadOnlyList<MotherBoardFormFactor> supportedFormFactors,
        int length,
        int height,
        int width)
    {
        new SystemUnitCaseFormatValidator().Validate(
            name,
            maximalVideoCardHeight,
            maximalVideoCardLength,
            supportedFormFactors,
            length,
            height,
            width);

        Name = name;
        MaximalVideoCardHeight = maximalVideoCardHeight;
        MaximalVideoCardLength = maximalVideoCardLength;
        SupportedFormFactors = supportedFormFactors;
        Length = length;
        Height = height;
        Width = width;
    }

    public string Name { get; }

    public int MaximalVideoCardHeight { get; }

    public int MaximalVideoCardLength { get; }

    public IReadOnlyList<MotherBoardFormFactor> SupportedFormFactors { get; }

    public int Length { get; }

    public int Height { get; }

    public int Width { get; }
}