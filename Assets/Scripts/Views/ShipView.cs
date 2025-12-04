using UnityEngine;
using Zenject;

public class ShipView : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    public Transform ShootPoint => _shootPoint;

    private Ship _ship;

    [Inject]
    public void Construct(Ship ship)
    {
        _ship = ship;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _ship.FireBullets();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _ship.FireBeam();
    }
}

