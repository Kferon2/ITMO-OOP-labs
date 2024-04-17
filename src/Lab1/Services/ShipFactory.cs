using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ShipFactory
{
    private readonly ShellFactory _shellFactory = new();
    private readonly DeflectorFactory _deflectorFactory = new();

    public ShipBase PleasureShuttle()
    {
        return new ShipBase(
            _shellFactory.FirstClassShell(),
            null,
            new EngineImpulseClassC(),
            null,
            null);
    }

    public ShipBase Vaklas()
    {
        return new ShipBase(
            _shellFactory.SecondClassShell(),
            _deflectorFactory.FirstClassDeflector(),
            new EngineImpulseClassE(),
            new EngineJumpClassGamma(),
            null);
    }

    public ShipBase Meridian()
    {
        return new ShipBase(
            _shellFactory.SecondClassShell(),
            _deflectorFactory.SecondClassDeflector(),
            new EngineImpulseClassE(),
            null,
            new AntinitrineEmitter());
    }

    public ShipBase Stella()
    {
        return new ShipBase(
            _shellFactory.FirstClassShell(),
            _deflectorFactory.FirstClassDeflector(),
            new EngineImpulseClassC(),
            new EngineJumpClassOmega(),
            null);
    }

    public ShipBase Augur()
    {
        return new ShipBase(
            _shellFactory.ThirdClassShell(),
            _deflectorFactory.ThirdClassDeflector(),
            new EngineImpulseClassE(),
            new EhgineJumpClassAlpha(),
            null);
    }

    public ShipBase ModifyDeflectorPhoton(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship can't be null");
        }

        return new ShipBase(
            ship.Shell,
            _deflectorFactory.ModifyPhoton(ship.Deflector),
            ship.EngineImpulse,
            ship.EngineJump,
            ship.Emitter);
    }
}