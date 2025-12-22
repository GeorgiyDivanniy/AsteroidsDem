using UnityEngine;
using Infrastructure;
using Zenject;
using System;

namespace ViewModels
{
    public interface IHUDView
    {
        void SetPositionText(string text);
        void SetRotationText(string text);
        void SetSpeedText(string text);
        void SetBeamCharges(int current, int max);
        void SetBeamCooldownProgress(float progress); // 0..1
    }

    public class ShipHUDViewModel : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly IHUDView _view;

        public ShipHUDViewModel(EventBus eventBus, IHUDView view)
        {
            _eventBus = eventBus;
            _view = view;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<ShipStateUpdatedEvent>(OnShipStateUpdated);
            _eventBus.Subscribe<WeaponStateUpdatedEvent>(OnWeaponStateUpdated);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ShipStateUpdatedEvent>(OnShipStateUpdated);
            _eventBus.Unsubscribe<WeaponStateUpdatedEvent>(OnWeaponStateUpdated);
        }

        private void OnShipStateUpdated(ShipStateUpdatedEvent evt)
        {
            int x = Mathf.RoundToInt(evt.Position.x);
            int y = Mathf.RoundToInt(evt.Position.y);
            _view.SetPositionText($"X: {x}  Y: {y}");
            
            int angle = Mathf.RoundToInt(evt.RotationZ);
            _view.SetRotationText($"{angle}°");
            
            int speed = Mathf.RoundToInt(evt.SpeedKmH);
            _view.SetSpeedText($"{speed} km/h");
        }

        private void OnWeaponStateUpdated(WeaponStateUpdatedEvent evt)
        {
            _view.SetBeamCharges(evt.CurrentCharges, evt.MaxCharges);
            _view.SetBeamCooldownProgress(evt.CooldownProgress);
        }
    }
}