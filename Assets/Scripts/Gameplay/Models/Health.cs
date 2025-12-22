using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health 
{
    private float _healthPoints;

    public Health(float healthPoints)
    {
        _healthPoints = healthPoints;
    }

    public void HealHP(float healPoints)
    {
        _healthPoints += healPoints;
    }

    public void LoseHP(float damage)
    {
        _healthPoints -= damage;
    }
}
