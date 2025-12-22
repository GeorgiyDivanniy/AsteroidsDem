using UnityEngine;

namespace Infrastructure
{
    public struct ShipStateUpdatedEvent
    {
        public Vector2 Position;
        public float RotationZ;
        public float SpeedKmH;
    }

    public struct WeaponStateUpdatedEvent
    {
        public int CurrentCharges;
        public int MaxCharges;
        public float CooldownProgress; 
    }
}