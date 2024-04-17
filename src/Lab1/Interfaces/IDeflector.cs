namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public interface IDeflector : IDefensiveModule
{
    public bool IsAlive { get; }

    public int MaxHitPoints { get; }

    public int CurrentHitPoints { get; }
    public void Hit(int damage);
}