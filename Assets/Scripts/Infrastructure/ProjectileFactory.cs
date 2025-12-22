using UnityEngine;
using Zenject;

public class ProjectileFactory : IProjectileFactory
{
    private readonly DiContainer _container;
    private readonly BulletView _bulletPrefab;
    private readonly BeamView _beamPrefab;

    public ProjectileFactory(DiContainer container, BulletView bulletPrefab, BeamView beamPrefab)
    {
        _container = container;
        _bulletPrefab = bulletPrefab;
        _beamPrefab = beamPrefab;
    }

    public void CreateBullet(Vector2 position, Vector2 direction)
    {
        var bullet = _container.InstantiatePrefabForComponent<BulletView>(_bulletPrefab, position, Quaternion.identity, null);
        bullet.Launch(direction);
        Debug.Log("Bullet created");
    }

    public void CreateBeam(Vector2 position, Vector2 direction)
    {
        var beam = _container.InstantiatePrefabForComponent<BeamView>(_beamPrefab, position, Quaternion.identity, null);
        beam.Launch(direction);
    }
}
