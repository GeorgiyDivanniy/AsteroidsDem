using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileFactory
{
    void CreateBullet(Vector2 position, Vector2 direction);
    void CreateBeam(Vector2 position, Vector2 direction);
}
