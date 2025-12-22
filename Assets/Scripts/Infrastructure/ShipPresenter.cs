using Zenject;
using UnityEngine;
using Infrastructure;
using Models;
using Views;
using System;

namespace Infrastructure
{
    public class ShipPresenter : ITickable, IInitializable, IDisposable
    {
        private readonly CharacterMovement _input;
        private readonly ShipView _view;
        private readonly ShipMovementModel _movementModel;
        private readonly ShipModel _shipModel;
        private readonly EventBus _eventBus;

        private Vector2 _lastInput = Vector2.zero;

        public ShipPresenter(
            CharacterMovement input,
            ShipView view,
            ShipMovementModel movementModel,
            ShipModel shipModel,
            EventBus eventBus)
        {
            _input = input;
            _view = view;
            _movementModel = movementModel;
            _shipModel = shipModel;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _input.OnMoveInputChanged += OnMoveInputChanged;
        }

        public void Dispose()
        {
            _input.OnMoveInputChanged -= OnMoveInputChanged;
        }

        private void OnMoveInputChanged(Vector2 v)
        {
            _lastInput = v;
        }

        public void Tick()
        {
            float dt = Time.deltaTime;
            
            Vector2 dir = _lastInput;
            Vector2 dirNorm = dir.sqrMagnitude > 0.01f ? dir.normalized : Vector2.zero;
            
            _movementModel.UpdateMovement(dir, dt);
            
            Vector2 displacement = _movementModel.ComputeDisplacement(dirNorm, dt);
            _view.ApplyTranslation(displacement);
            
            float rotZ = _view.GetRotationZ();
            
            float speedKmH = _movementModel.GetSpeedKmH();
            
            _shipModel.ApplyState(_view.GetPosition(), rotZ, speedKmH);
            
            var evt = new ShipStateUpdatedEvent
            {
                Position = _shipModel.Position,
                RotationZ = _shipModel.AngleZ,
                SpeedKmH = _shipModel.SpeedKmH
            };

            _eventBus.Publish(evt);
        }
    }
}