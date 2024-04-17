using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.SystemUnitCase;

public class SystemUnitCaseBuilder : ISystemUnitCaseBuilder
{
    private readonly List<MotherBoardFormFactor> _supportedFormFactors = new();
    private string? _name;
    private int? _maximalVideoCardLength;
    private int? _maximalVideoCardWidth;
    private int? _length;
    private int? _height;
    private int? _width;

    public ISystemUnitCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISystemUnitCaseBuilder WithMaximalVideoCardHeight(int maximalVideoCardWidth)
    {
        _maximalVideoCardWidth = maximalVideoCardWidth;
        return this;
    }

    public ISystemUnitCaseBuilder WithMaximalVideoCardLength(int maximalVideoCardLength)
    {
        _maximalVideoCardLength = maximalVideoCardLength;
        return this;
    }

    public ISystemUnitCaseBuilder AddSupportedFormFactor(MotherBoardFormFactor factor)
    {
        _supportedFormFactors.Add(factor);
        return this;
    }

    public ISystemUnitCaseBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public ISystemUnitCaseBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public ISystemUnitCaseBuilder WidthHeight(int height)
    {
        _height = height;
        return this;
    }

    public ISystemUnitCaseBuilder Direct(SystemUnitCase component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WidthHeight(component.Height)
            .WithLength(component.Length)
            .WithWidth(component.Width)
            .WithMaximalVideoCardHeight(component.MaximalVideoCardHeight)
            .WithMaximalVideoCardLength(component.MaximalVideoCardLength);
        foreach (MotherBoardFormFactor formFactor in component.SupportedFormFactors)
            AddSupportedFormFactor(formFactor);

        return this;
    }

    public SystemUnitCase Build()
    {
        return new Components.SystemUnitCase.SystemUnitCase(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _maximalVideoCardWidth ?? throw new ArgumentNullException(nameof(_maximalVideoCardWidth)),
            _maximalVideoCardLength ?? throw new ArgumentNullException(nameof(_maximalVideoCardLength)),
            _supportedFormFactors,
            _length ?? throw new ArgumentNullException(nameof(_length)),
            _height ?? throw new ArgumentNullException(nameof(_length)),
            _width ?? throw new ArgumentNullException(nameof(_width)));
    }
}