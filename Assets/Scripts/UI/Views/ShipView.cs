using UnityEngine;
using Zenject;

public class ShipView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    public Transform ShootPoint => _shootPoint;
    
    public void ApplyTranslation(Vector2 displacement)
    {
        transform.Translate(displacement, Space.World);
    }

    public void ApplyRotation(float angleZ)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angleZ);
    }

    public Vector2 GetPosition() => transform.position;
    public float GetRotationZ() => transform.eulerAngles.z;
    
}


