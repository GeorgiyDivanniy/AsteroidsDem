using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private ShipView _shipView;
    [SerializeField] private BulletView _bulletPrefab;
    [SerializeField] private BeamView _beamPrefab;

    public override void InstallBindings()
    {
        Container.Bind<IProjectileFactory>()
            .To<ProjectileFactory>()
            .AsSingle()
            .WithArguments(_bulletPrefab, _beamPrefab);

        Container.Bind<IWeapon>()
            .WithId("Bullet")
            .To<BulletWeapon>()
            .AsTransient()
            .WithArguments(_shipView.ShootPoint);

        Container.Bind<IWeapon>()
            .WithId("Beam")
            .To<BeamWeapon>()
            .AsSingle()
            .WithArguments(_shipView.ShootPoint, 3, 2f);

        Container.Bind<Ship>().FromMethod(context =>
        {
            var bullet = context.Container.ResolveId<IWeapon>("Bullet");
            var beam = context.Container.ResolveId<IWeapon>("Beam");
            return new Ship(bullet, beam);
        }).AsSingle();

        Container.Bind<ShipView>().FromInstance(_shipView).AsSingle();
    }
}

