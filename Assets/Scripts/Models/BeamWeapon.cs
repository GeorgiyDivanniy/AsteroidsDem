using System;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamWeapon : IWeapon
{
    private readonly IProjectileFactory _factory;
    private readonly Transform _shootPoint;
    private readonly int _maxCharges;
    private readonly float _rechargeDelay;
    private int _currentCharges;
    private bool _isRecharging;

    public event Action<int, int> OnChargeChanged; 

    public BeamWeapon(IProjectileFactory factory, Transform shootPoint, int maxCharges, float rechargeDelay)
    {
        _factory = factory;
        _shootPoint = shootPoint;
        _maxCharges = maxCharges;
        _rechargeDelay = rechargeDelay;
        _currentCharges = maxCharges;
    }

    public void Fire()
    {
        if (_currentCharges <= 0)
            return;

        _factory.CreateBeam(_shootPoint.position, _shootPoint.up);
        _currentCharges--;
        OnChargeChanged?.Invoke(_currentCharges, _maxCharges);

        if (!_isRecharging)
            RechargeAsync().Forget();
    }

    private async UniTaskVoid RechargeAsync()
    {
        _isRecharging = true;

        while (_currentCharges < _maxCharges)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_rechargeDelay));
            _currentCharges++;
            OnChargeChanged?.Invoke(_currentCharges, _maxCharges);
        }

        _isRecharging = false;
    }
}
