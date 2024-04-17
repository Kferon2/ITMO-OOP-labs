using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class AreaCosmos : IArea
{
    public AreaCosmos(int length, IReadOnlyCollection<ObstaclePhysical> obstacles)
    {
        if (length < 0)
        {
            throw new ArgumentException("Area length must be positive", nameof(length));
        }

        Length = length;
        Obstacles = obstacles;
    }

    public int Length { get; private set; }

    public IReadOnlyCollection<IDamageDealer> Obstacles { get; }

    public double AcceptVisitor(IAreaVisitor areaVisitor)
    {
        if (areaVisitor == null)
        {
            throw new ArgumentNullException(nameof(areaVisitor), "Area visitor can't be null");
        }

        return areaVisitor.VisitArea(this);
    }
}