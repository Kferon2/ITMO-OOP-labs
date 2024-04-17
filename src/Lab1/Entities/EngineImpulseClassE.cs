using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class EngineImpulseClassE : IEngineImpulse
{
    public double StartFuelAmount => 1;
    public double MaxSpeed => 30;

    public double VisitArea(AreaCosmos cosmos)
    {
        if (cosmos == null)
        {
            throw new ArgumentNullException(nameof(cosmos), "Area can't be null");
        }

        double optimalFlightTime = Math.Log(cosmos.Length);
        double optimalSpeed = Math.Min(cosmos.Length / optimalFlightTime, MaxSpeed);
        double accelerationTime = Math.Log(optimalSpeed);
        double efficiency = optimalSpeed / MaxSpeed;
        return FuelConsumption(optimalFlightTime, efficiency) + FuelConsumption(accelerationTime, 1) + StartFuelAmount;
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

        double optimalFlightTime = Math.Log(nitrineNebula.Length);
        double optimalSpeed = Math.Min(nitrineNebula.Length / optimalFlightTime, MaxSpeed);
        double accelerationTime = Math.Log(optimalSpeed);
        double efficiency = optimalSpeed / MaxSpeed;
        return FuelConsumption(optimalFlightTime, efficiency) + FuelConsumption(accelerationTime, 1) + StartFuelAmount;
    }

    public double FuelConsumption(double workingTime, double efficiencyCoefficient)
    {
        if (workingTime < 0)
        {
            throw new ArgumentException("Working time can't be negative", nameof(workingTime));
        }

        if (efficiencyCoefficient > 1)
        {
            throw new ArgumentException("Efficiency coefficient can't be higher than 1", nameof(workingTime));
        }

        if (efficiencyCoefficient < 0)
        {
            throw new ArgumentException("Efficiency coefficient can't be negative", nameof(workingTime));
        }

        return workingTime * MaxSpeed * efficiencyCoefficient;
    }
}