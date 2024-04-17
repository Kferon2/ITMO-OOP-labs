using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolingSystem;

public class CoolingSystem : IComponent
{
    public CoolingSystem(string name, int width, int height, int length, Sockets sockets, int tdp)
    {
        new CoolingSystemFormatValidator().Validate(
            name,
            width,
            length,
            height,
            sockets,
            tdp);
        Name = name;
        Width = width;
        Height = height;
        Length = length;
        Sockets = sockets;
        TDP = tdp;
    }

    public string Name { get; }

    public int Width { get; }

    public int Height { get; }

    public int Length { get; }

    public Sockets Sockets { get; }

    public int TDP { get; }
}