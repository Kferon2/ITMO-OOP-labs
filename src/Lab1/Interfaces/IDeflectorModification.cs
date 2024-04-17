namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IDeflectorModification : IDeflector
{
    public IDeflector Deflector { get; }
}