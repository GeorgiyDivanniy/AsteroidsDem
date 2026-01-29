using System;
using Cysharp.Threading.Tasks;
using Models;
using UnityEngine;

public class BeamWeapon : IWeapon, IChargeableWeapon
{
    private readonly ProjectileFactory _factory;
    private readonly Vector3 _shootPoint;
    private readonly int _maxCharges;
    private readonly float _rechargeDelay;
    private int _currentCharges;
    private bool _isRecharging;

    public event Action<int, int> OnChargeChanged; 
    public event Action<float> OnCooldownProgressChanged;
    public BeamWeapon(ProjectileFactory factory, Vector3 shootPoint, int maxCharges, float rechargeDelay)
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

        _factory.CreateBeam(_shootPoint);
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
            float elapsed = 0f;
            while (elapsed < _rechargeDelay)
            {
                await UniTask.Yield();
                elapsed += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsed / _rechargeDelay);
                OnCooldownProgressChanged?.Invoke(progress);
            }

            _currentCharges++;
            OnChargeChanged?.Invoke(_currentCharges, _maxCharges);
            OnCooldownProgressChanged?.Invoke(0f);
        }

        _isRecharging = false;
        OnCooldownProgressChanged?.Invoke(0f);
    }
}
