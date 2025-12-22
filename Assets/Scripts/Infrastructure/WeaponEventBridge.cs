using Zenject;
using Models;
using Infrastructure;
using System;

public class WeaponEventBridge : IInitializable, IDisposable
{
    private readonly EventBus _bus;
    private readonly IChargeableWeapon _beam;
    private readonly IWeapon _weapon;

    public WeaponEventBridge(EventBus bus, [Inject(Id="Beam")] IWeapon weapon,[Inject(Id = "Beam")]IChargeableWeapon beam)
    {
        _bus = bus;
        _weapon = weapon;
        _beam = beam;
    }

    public void Initialize()
    {
        _beam.OnChargeChanged += OnChargeChanged;
        _beam.OnCooldownProgressChanged += OnCooldownChanged;
    }

    public void Dispose()
    {
        _beam.OnChargeChanged -= OnChargeChanged;
        _beam.OnCooldownProgressChanged -= OnCooldownChanged;
    }

    private void OnChargeChanged(int current, int max)
    {
        var evt = new WeaponStateUpdatedEvent
        {
            CurrentCharges = current,
            MaxCharges = max,
            CooldownProgress = 0f
        };
        _bus.Publish(evt);
    }

    private void OnCooldownChanged(float progress)
    {
        var evt = new WeaponStateUpdatedEvent
        {
            CurrentCharges = -1,
            MaxCharges = -1,
            CooldownProgress = progress
        };
        _bus.Publish(evt);
    }
}