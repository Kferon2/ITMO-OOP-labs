namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IEngine : IAreaVisitor
{
    public double FuelConsumption(double workingTime, double efficiencyCoefficient);
}