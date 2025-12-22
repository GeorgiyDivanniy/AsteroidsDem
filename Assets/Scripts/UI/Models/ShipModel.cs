using UnityEngine;

namespace Models
{
    public class ShipModel
    {
        public Vector2 Position { get; private set; }
        public float AngleZ { get; private set; }
        public float SpeedKmH { get; private set; }

        public void ApplyState(Vector2 pos, float angleZ, float speedKmH)
        {
            Position = pos;
            AngleZ = angleZ;
            SpeedKmH = speedKmH;
        }
    }
}