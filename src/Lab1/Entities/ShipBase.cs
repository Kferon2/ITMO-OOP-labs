using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ShipBase
{
    public ShipBase(
        ShellBasic shell,
        IDeflector? deflector,
        IEngineImpulse? engineImpulse,
        IEngineJump? engineJump,
        AntinitrineEmitter? emitter)
    {
        if (engineJump == null && engineImpulse == null)
        {
            throw new ArgumentNullException(nameof(engineJump), "There must be at least one engine in a ship");
        }

        EngineJump = engineJump;
        EngineImpulse = engineImpulse;
        Shell = shell ?? throw new ArgumentNullException(nameof(shell));
        Deflector = deflector;
        Emitter = emitter;
        IsCrewAlive = true;
    }

    public bool IsShipAlive => Shell.IsAlive;

    public bool IsCrewAlive { get; private set; }

    public int FuelCapacity { get; set; }

    public IDeflector? Deflector { get; private set; }

    public ShellBasic Shell { get; private set; }

    public AntinitrineEmitter? Emitter { get; private set; }

    public IEngineJump? EngineJump { get; private set; }

    public IEngineImpulse? EngineImpulse { get; private set; }

    public void AcceptDamage(IDamageDealer obstacle)
    {
        if (obstacle == null)
        {
            throw new ArgumentNullException(nameof(obstacle), "Obstacle can't be null");
        }

        Emitter?.AcceptDamage(obstacle);
        Deflector?.AcceptDamage(obstacle);
        Shell.AcceptDamage(obstacle);

        obstacle.AffectShipCrew(this);
    }

    public double AreaTravelImpulse(IArea area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area), "Area can't be null");
        }

        if (EngineImpulse == null) return -1;
        return area.AcceptVisitor(EngineImpulse);
    }

    public double AreaTravelJump(IArea area)
    {
        if (area == null)
        {
            throw new ArgumentNullException(nameof(area), "Area can't be null");
        }

        if (EngineJump == null) return -1;
        return area.AcceptVisitor(EngineJump);
    }

    public void KillCrew()
    {
        IsCrewAlive = false;
    }
}