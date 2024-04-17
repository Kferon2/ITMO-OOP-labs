using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CoolingSystem;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithName(string name);

    ICoolingSystemBuilder WithWidth(int width);

    ICoolingSystemBuilder WithLength(int length);

    ICoolingSystemBuilder WithHeight(int heigth);

    ICoolingSystemBuilder WithSockets(Sockets sockets);

    ICoolingSystemBuilder WithTdp(int tdp);

    ICoolingSystemBuilder Direct(CoolingSystem component);

    CoolingSystem Build();
}