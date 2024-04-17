namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IEngineJump : IEngine
{
    public double TravelDistance { get; }
    public double Speed { get; }
}