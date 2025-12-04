using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : IWeapon
{
    private readonly IProjectileFactory _factory;
    private readonly Transform _shootPoint;

    public BulletWeapon(IProjectileFactory factory, Transform shootPoint)
    {
        _factory = factory;
        _shootPoint = shootPoint;
    }

    public void Fire()
    {
        _factory.CreateBullet(_shootPoint.position, _shootPoint.up);
    }
}
