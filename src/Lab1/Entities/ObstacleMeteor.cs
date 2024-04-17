namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ObstacleMeteor : ObstaclePhysical
{
    private const int MeteorDamage = 400;

    public ObstacleMeteor()
        : base(MeteorDamage, MeteorDamage)
    {
    }
}