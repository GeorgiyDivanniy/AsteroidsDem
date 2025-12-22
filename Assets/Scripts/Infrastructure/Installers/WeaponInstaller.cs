using Models;
using Infrastructure;
using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    [Header("Scene references")]
    [SerializeField] private ShipView shipView;
    [SerializeField] private BulletView bulletPrefab;
    [SerializeField] private BeamView beamPrefab;
    public override void InstallBindings()
    {
        Container.Bind<IProjectileFactory>()
            .To<ProjectileFactory>()
            .AsSingle()
            .WithArguments(bulletPrefab, beamPrefab);
        
        Container.Bind<IWeapon>()
            .WithId("Bullet")
            .To<BulletWeapon>()
            .AsTransient()
            .WithArguments(shipView.ShootPoint);

        Container.Bind<BeamWeapon>()
            .AsSingle()
            .WithArguments(shipView.ShootPoint, 3, 2f);

        Container.Bind<IWeapon>()
            .WithId("Beam").To<BeamWeapon>().FromResolve();
        
        Container.Bind<IChargeableWeapon>()
            .WithId("Beam")
            .FromResolve();
        Container.Bind<WeaponController>()
            .FromComponentInHierarchy()
            .AsSingle();
       
    }
}