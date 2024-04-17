using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class EngineJumpClassGamma : IEngineJump
{
    public double TravelDistance => 100;

    public double Speed => 10;

    public double VisitArea(AreaCosmos cosmos)
    {
        return -1;
    }

    public double VisitArea(AreaHighDensityNebula densityNebula)
    {
        if (densityNebula == null)
        {
            throw new ArgumentNullException(nameof(densityNebula), "Area can't be null");
        }

        int distance = densityNebula.Length;
        if (distance > TravelDistance) return -1;
        double time = distance / Speed;
        return FuelConsumption(time);
    }

    public double VisitArea(AreaNitrineNebula nitrineNebula)
    {
        return -1;
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

        return Math.Pow(workingTime, 2) * Speed * efficiencyCoefficient;
    }
}