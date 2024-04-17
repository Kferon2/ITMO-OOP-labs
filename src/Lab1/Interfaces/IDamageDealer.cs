using Itmo.ObjectOrientedProgramming.Lab1.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IDamageDealer
{
    public void DealDamage(Deflector? deflectorBasic);

    public void DealDamage(DeflectorPhoton? deflectorPhoton);

    public void DealDamage(ShellBasic shellBasic);

    public void DealDamage(AntinitrineEmitter? antinitrineEmitter);

    public void AffectShipCrew(ShipBase ship);
}