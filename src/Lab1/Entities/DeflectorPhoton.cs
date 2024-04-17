using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class DeflectorPhoton : IDeflectorModification
{
    public DeflectorPhoton(IDeflector deflectorBasic, int deflectionsCount = 3)
    {
        if (deflectionsCount < 0)
        {
            throw new ArgumentException("Number of possible deflections must be positive", nameof(deflectionsCount));
        }

        Deflector = deflectorBasic ??
                          throw new ArgumentNullException(nameof(deflectorBasic), "Deflector can't be null");

        DeflectionsCount = deflectionsCount;
    }

    public int DeflectionsCount { get; private set; }

    public IDeflector Deflector { get; private set; }

    public bool IsAlive => Deflector.IsAlive;
    public int MaxHitPoints => Deflector.MaxHitPoints;
    public int CurrentHitPoints => Deflector.CurrentHitPoints;

    public void Hit(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Number of flashes must be positive", nameof(damage));
        }

        DeflectionsCount -= damage;
    }

    public void AcceptDamage(IDamageDealer damageDealer)
    {
        if (damageDealer == null)
        {
            throw new ArgumentNullException(nameof(damageDealer), "Obstacle can't be null");
        }

        damageDealer.DealDamage(this);
    }
}