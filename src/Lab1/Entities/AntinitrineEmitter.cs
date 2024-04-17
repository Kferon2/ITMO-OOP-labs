using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class AntinitrineEmitter : IDefensiveModule
{
    public AntinitrineEmitter(int maxChargeParticlesCount = 1, int currentChargeParticlesCount = 1)
    {
        if (maxChargeParticlesCount < 0)
        {
            throw new ArgumentException("Maximum hit points must be positive", nameof(maxChargeParticlesCount));
        }

        if (currentChargeParticlesCount < 0)
        {
            throw new ArgumentException("Current hit points must be positive", nameof(currentChargeParticlesCount));
        }

        MaxChargeParticlesCount = maxChargeParticlesCount;
        CurrentChargeParticlesCount = currentChargeParticlesCount;
    }

    public bool IsAlive => CurrentChargeParticlesCount > 0;

    private int MaxChargeParticlesCount { get; }
    private int CurrentChargeParticlesCount { get; set; }

    public void AcceptDamage(IDamageDealer damageDealer)
    {
        if (damageDealer == null)
        {
            throw new ArgumentNullException(nameof(damageDealer), "Obstacle can't be null");
        }

        damageDealer.DealDamage(this);
    }

    public void Hit(int chargesNumber = 1)
    {
        if (!IsAlive) return;
        if (chargesNumber < 0)
        {
            throw new ArgumentException("Number of charges must be positive", nameof(chargesNumber));
        }

        int actual = chargesNumber > CurrentChargeParticlesCount ? CurrentChargeParticlesCount : chargesNumber;

        CurrentChargeParticlesCount -= actual;
    }
}