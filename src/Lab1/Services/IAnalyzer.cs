using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IAnalyzer : IObserver
{
    public PathResult FlightAnalyze(Path path, ShipBase ship);
}