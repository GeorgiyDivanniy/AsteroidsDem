using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Infrastructure
{
    public class WeaponController : MonoBehaviour
    {
        private GameInput _input;

        private IWeapon _bulletWeapon;
        private IWeapon _beamWeapon;

        [Inject]
        public void Construct([Inject(Id = "Bullet")]IWeapon bulletWeapon, [Inject(Id = "Beam")]IWeapon beamWeapon)
        {
            _bulletWeapon = bulletWeapon;
            _beamWeapon = beamWeapon;
        }

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Gameplay.Shoot.performed += OnFireBullet;
            _input.Gameplay.ShootBeam.performed += OnFireBeam;
        }

        private void OnDisable()
        {
            _input.Gameplay.Shoot.performed -= OnFireBullet;
            _input.Gameplay.ShootBeam.performed -= OnFireBeam;
            _input.Disable();
        }

        private void OnFireBullet(InputAction.CallbackContext ctx)
        {
            _bulletWeapon?.Fire();
        }

        private void OnFireBeam(InputAction.CallbackContext ctx)
        {
            _beamWeapon?.Fire();
        }
    } 
}
