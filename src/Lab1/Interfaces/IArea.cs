using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IArea
{
    public int Length { get; }
    public IReadOnlyCollection<IDamageDealer> Obstacles { get; }
    public double AcceptVisitor(IAreaVisitor areaVisitor);
}