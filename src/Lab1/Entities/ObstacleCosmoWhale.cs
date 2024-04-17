using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ObstacleCosmoWhale : IDamageDealer
{
    private const int WhaleDamage = 4000;

    public ObstacleCosmoWhale(int whalePopulation)
    {
        if (whalePopulation < 0)
        {
            throw new ArgumentException("Number of whales can't be negative", nameof(whalePopulation));
        }

        WhalePopulation = whalePopulation;
        MaxDamage = WhaleDamage * whalePopulation;
        CurrentDamage = WhaleDamage * whalePopulation;
    }

    public int WhalePopulation { get; private set; }
    public int MaxDamage { get; private set; }
    public bool IsAlive => CurrentDamage > 0;
    public int CurrentDamage { get; private set; }

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
        if (antinitrineEmitter == null || !antinitrineEmitter.IsAlive) return;
        antinitrineEmitter.Hit();
        CurrentDamage = 0;
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