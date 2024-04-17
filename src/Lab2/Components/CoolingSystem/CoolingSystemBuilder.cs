using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolingSystem;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private string? _name;
    private int? _width;
    private int? _height;
    private int? _length;
    private int? _tdp;
    private Sockets? _sockets;

    public ICoolingSystemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICoolingSystemBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public ICoolingSystemBuilder WithLength(int length)
    {
        _length = length;
        return this;
    }

    public ICoolingSystemBuilder WithHeight(int heigth)
    {
        _height = heigth;
        return this;
    }

    public ICoolingSystemBuilder WithSockets(Sockets sockets)
    {
        _sockets = sockets;
        return this;
    }

    public ICoolingSystemBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICoolingSystemBuilder Direct(CoolingSystem component)
    {
        if (component == null) throw new ArgumentNullException(nameof(component));

        WithName(component.Name)
            .WithHeight(component.Height)
            .WithLength(component.Length)
            .WithSockets(component.Sockets)
            .WithTdp(component.TDP)
            .WithWidth(component.Width);

        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _width ?? throw new ArgumentNullException(nameof(_width)),
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _length ?? throw new ArgumentNullException(nameof(_length)),
            _sockets ?? throw new ArgumentNullException(nameof(_sockets)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)));
    }
}