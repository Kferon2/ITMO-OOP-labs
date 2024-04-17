using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Path
{
    public Path(IEnumerable<IArea> areas)
    {
        Areas = areas;
    }

    public IEnumerable<IArea> Areas { get; }
}