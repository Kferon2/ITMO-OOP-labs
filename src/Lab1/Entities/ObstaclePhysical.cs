using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ObstaclePhysical : IDamageDealer
{
    public ObstaclePhysical(int maxDamage, int currentDamage)
    {
        if (maxDamage < 0)
        {
            throw new ArgumentException("Damage must be positive", nameof(maxDamage));
        }

        if (currentDamage < 0)
        {
            throw new ArgumentException("Damage must be positive", nameof(currentDamage));
        }

        MaxDamage = maxDamage;
        CurrentDamage = currentDamage;
    }

    public int MaxDamage { get; private set; }
    public bool IsAlive => CurrentDamage > 0;
    public int CurrentDamage { get; protected set; }

    public void DealDamage(Deflector? deflectorBasic)
    {
        if (deflectorBasic == null) return;

        if (!IsAlive) return;
        int actual = deflectorBasic.CurrentHitPoints > CurrentDamage ? CurrentDamage : deflectorBasic.CurrentHitPoints;
        deflectorBasic.Hit(actual);
        Hit(actual);
    }

    public void DealDamage(DeflectorPhoton? deflectorPhoton)
    {
        deflectorPhoton?.Deflector.AcceptDamage(this);
    }

    public void DealDamage(ShellBasic shellBasic)
    {
        if (shellBasic == null)
        {
            throw new ArgumentNullException(nameof(shellBasic), "Shell can't be null");
        }

        if (!IsAlive) return;
        int actual = shellBasic.CurrentHitPoints > CurrentDamage ? CurrentDamage : shellBasic.CurrentHitPoints;
        shellBasic.Hit(actual);
        Hit(actual);
    }

    public void DealDamage(AntinitrineEmitter? antinitrineEmitter)
    {
    }

    public void AffectShipCrew(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship can't be null");
        }
    }

    public void Heal()
    {
        CurrentDamage = MaxDamage;
    }

    private void Hit(int damage)
    {
        if (!IsAlive) return;
        if (damage < 0)
        {
            throw new ArgumentException("damage must be positive", nameof(damage));
        }

        CurrentDamage -= damage;
    }
}