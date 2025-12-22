using UnityEngine;

namespace Models
{
    public class ShipMovementModel
    {
        public float CurrentSpeed { get; private set; }
        public float MaxSpeed { get; }
        public float Acceleration { get; }
        public float Braking { get; }

        public ShipMovementModel(float maxSpeed, float acceleration, float braking)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            Braking = braking;
            CurrentSpeed = 0f;
        }
        
        public void UpdateMovement(Vector2 direction, float deltaTime)
        {
            if (direction.sqrMagnitude > 0.01f)
            {
                CurrentSpeed += Acceleration * deltaTime;
            }
            else
            {
                CurrentSpeed -= Braking * deltaTime;
            }

            CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, MaxSpeed);
        }
        
        public Vector2 ComputeDisplacement(Vector2 directionNormalized, float deltaTime)
        {
            return directionNormalized * CurrentSpeed * deltaTime;
        }
        
        public float GetSpeedKmH() => CurrentSpeed * 3.6f;
    }
}