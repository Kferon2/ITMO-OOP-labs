using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class DeflectorFactory
{
    public Deflector FirstClassDeflector()
    {
        return new Deflector(400, 400);
    }

    public Deflector SecondClassDeflector()
    {
        return new Deflector(1200, 1200);
    }

    public Deflector ThirdClassDeflector()
    {
        return new Deflector(4000, 4000);
    }

    public IDeflector? ModifyPhoton(IDeflector? deflector)
    {
        if (deflector == null) return null;
        return new DeflectorPhoton(deflector);
    }
}