namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class PathResult
{
    public double FlightCost { get; set; }

    public bool IsCrewAlive { get; set; } = true;

    public bool IsShipAlive { get; set; } = true;

    public double FlightFuel { get; set; }

    public bool IsShipVisible { get; set; } = true;

    public bool Success { get; set; } = true;
}