using UnityEngine;

public class BulletWeapon : IWeapon
{
    //private readonly IProjectileFactory _factory;
    private readonly Transform _shootPoint;

    public BulletWeapon(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }

    public void Fire()
    {
        //_factory.CreateBullet(_shootPoint.position, _shootPoint.up);
    }
}
