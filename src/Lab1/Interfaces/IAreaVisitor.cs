using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IAreaVisitor
{
    public double VisitArea(AreaCosmos cosmos);

    public double VisitArea(AreaHighDensityNebula densityNebula);

    public double VisitArea(AreaNitrineNebula nitrineNebula);
}