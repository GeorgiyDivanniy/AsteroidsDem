using Models;
using Infrastructure;
using Models.Pools;
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
        var factory = new UniversalFactory();
        factory.Register(new PoolProvider<BulletView>(Container, bulletPrefab,20));
        factory.Register(new PoolProvider<BeamView>(Container, beamPrefab, 5));
        
        Container.Bind<UniversalFactory>().FromInstance(factory).AsSingle();
        Container.Bind<ProjectileFactory>().AsSingle();
        
        /*Container.Bind<IProjectileFactory>()
            .To<ProjectileFactory>()
            .AsSingle()
            .WithArguments(bulletPrefab, beamPrefab);*/
        
        Container.Bind<IWeapon>()
            .WithId("Bullet")
            .To<BulletWeapon>()
            .AsTransient()
            .WithArguments(shipView.ShootPoint.position);

        Container.Bind<BeamWeapon>()
            .AsSingle()
            .WithArguments(shipView.ShootPoint.position, 3, 2f);

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