using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Deflector : IDeflector
{
    public Deflector(int maxHitPoints, int currentHitPoints)
    {
        if (maxHitPoints < 0)
        {
            throw new ArgumentException("Maximum hit points must be positive", nameof(maxHitPoints));
        }

        if (currentHitPoints < 0)
        {
            throw new ArgumentException("Current hit points must be positive", nameof(currentHitPoints));
        }

        MaxHitPoints = maxHitPoints;
        CurrentHitPoints = currentHitPoints;
    }

    public int MaxHitPoints { get; private set; }

    public bool IsAlive => CurrentHitPoints > 0;
    public int CurrentHitPoints { get; private set; }

    public void AcceptDamage(IDamageDealer damageDealer)
    {
        if (damageDealer == null)
        {
            throw new ArgumentNullException(nameof(damageDealer), "Obstacle can't be null");
        }

        damageDealer.DealDamage(this);
    }

    public void Hit(int damage)
    {
        if (!IsAlive) return;
        if (damage < 0)
        {
            throw new ArgumentException("Damage must be positive", nameof(damage));
        }

        int actual = damage > CurrentHitPoints ? CurrentHitPoints : damage;

        CurrentHitPoints -= actual;
    }
}