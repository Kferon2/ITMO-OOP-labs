using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class EngineImpulseClassC : IEngineImpulse
{
    public double StartFuelAmount => 0.2;
    public double MaxSpeed => 5;

    public double VisitArea(AreaCosmos cosmos)
    {
        if (cosmos == null)
        {
            throw new ArgumentNullException(nameof(cosmos), "Area can't be null");
        }

        int distance = cosmos.Length;
        double time = distance / MaxSpeed;
        return FuelConsumption(time) + StartFuelAmount;
    }

    public double VisitArea(AreaHighDensityNebula densityNebula)
    {
        return -1;
    }

    public double VisitArea(AreaNitrineNebula nitrineNebula)
    {
        if (nitrineNebula == null)
        {
            throw new ArgumentNullException(nameof(nitrineNebula), "Area can't be null");
        }

        int distance = nitrineNebula.Length;
        double time = distance / (MaxSpeed * nitrineNebula.SlowingCoefficient);
        return FuelConsumption(time) + StartFuelAmount;
    }

    public double FuelConsumption(double workingTime, double efficiencyCoefficient = 1)
    {
        if (workingTime < 0)
        {
            throw new ArgumentException("Working time can't be negative", nameof(workingTime));
        }

        if (efficiencyCoefficient > 1)
        {
            throw new ArgumentException("Efficiency coefficient can't be higher than 1", nameof(workingTime));
        }

        return workingTime * MaxSpeed * efficiencyCoefficient;
    }
}