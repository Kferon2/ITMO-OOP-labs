namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IEngineImpulse : IEngine
{
    public double StartFuelAmount { get; }
    public double MaxSpeed { get; }
}