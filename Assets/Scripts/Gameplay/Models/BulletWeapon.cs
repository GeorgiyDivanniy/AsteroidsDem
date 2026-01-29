using UnityEngine;

public class BulletWeapon : IWeapon
{
    private readonly ProjectileFactory _factory;
    private readonly Vector3 _shootPoint;

    public BulletWeapon(ProjectileFactory factory, Vector3 shootPoint)
    {
        _shootPoint = shootPoint;
        _factory = factory;
    }

    public void Fire()
    {
        var bullet = _factory.CreateBullet(_shootPoint);
        bullet.Launch(Vector2.up);
    }
}
