using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ObstacleAntimatterFlash : IDamageDealer
{
    public ObstacleAntimatterFlash(int maxFlashesNumber, int currentFlashesNumber)
    {
        if (maxFlashesNumber < 0)
        {
            throw new ArgumentNullException(nameof(maxFlashesNumber), "Number of flashes must be positive");
        }

        if (currentFlashesNumber < 0)
        {
            throw new ArgumentNullException(nameof(currentFlashesNumber), "Number of flashes must be positive");
        }

        MaxFlashesNumber = maxFlashesNumber;
        CurrentFlashesNumber = currentFlashesNumber;
    }

    public int MaxFlashesNumber { get; private set; }

    public int CurrentFlashesNumber { get; private set; }

    public bool IsAlive => CurrentFlashesNumber > 0;

    public void DealDamage(Deflector? deflectorBasic)
    {
    }

    public void DealDamage(DeflectorPhoton? deflectorPhoton)
    {
        if (deflectorPhoton == null) return;
        int actual = deflectorPhoton.DeflectionsCount > CurrentFlashesNumber
            ? CurrentFlashesNumber
            : deflectorPhoton.DeflectionsCount;

        deflectorPhoton.Hit(actual);
        Hit(actual);
    }

    public void DealDamage(ShellBasic shellBasic)
    {
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

        if (CurrentFlashesNumber > 0)
        {
            ship.KillCrew();
        }
    }

    public void Heal()
    {
        CurrentFlashesNumber = MaxFlashesNumber;
    }

    private void Hit(int damage)
    {
        if (!IsAlive) return;
        if (damage < 0)
        {
            throw new ArgumentException("Number of flashes must be positive", nameof(damage));
        }

        CurrentFlashesNumber -= damage;
    }
}