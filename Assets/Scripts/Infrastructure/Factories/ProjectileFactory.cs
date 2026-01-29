using Infrastructure;
using UnityEngine;
using Zenject;

public class ProjectileFactory 
{
    private readonly UniversalFactory _factory;

    public ProjectileFactory(UniversalFactory factory)
    {
        _factory = factory;
    }

    public BulletView CreateBullet(Vector3 position)
    {
        return _factory.Create<BulletView>(position);
    }

    public BeamView CreateBeam(Vector3 position)
    {
        return _factory.Create<BeamView>(position);
    }
}
