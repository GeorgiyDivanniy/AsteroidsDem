using System;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class TeleportHandler: IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        public TeleportHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ExitedScreenBoundsSignal>(OnExitedBounds);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ExitedScreenBoundsSignal>(OnExitedBounds);
        }

        private void OnExitedBounds(ExitedScreenBoundsSignal signal)
        {
            Transform target = signal.Target;
            
            float halfHeight = Camera.main.orthographicSize;
            
            float halfWidth = halfHeight * Camera.main.aspect;

            Vector3 pos = target.position;

            if (pos.x > halfWidth)
                pos.x = -halfWidth;
            else if (pos.x < -halfWidth)
                pos.x = halfWidth;

            if (pos.y > halfHeight)
                pos.y = -halfHeight;
            else if (pos.y < -halfHeight)
                pos.y = halfHeight;

            target.position = pos;
        }
    }
}