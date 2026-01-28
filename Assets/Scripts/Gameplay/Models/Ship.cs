public class Ship
{
    private readonly IWeapon _bulletWeapon;
    private readonly IWeapon _beamWeapon;

    public Ship(IWeapon bulletWeapon, IWeapon beamWeapon)
    {
        _bulletWeapon = bulletWeapon;
        _beamWeapon = beamWeapon;
    }

    public void FireBullets()
    {
        _bulletWeapon.Fire();
    }

    public void FireBeam()
    {
        _beamWeapon.Fire();
    }
}

