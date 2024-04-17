namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class ObstacleAsteroid : ObstaclePhysical
{
    private const int AsteroidDamage = 100;

    public ObstacleAsteroid()
        : base(AsteroidDamage, AsteroidDamage)
    {
    }
}