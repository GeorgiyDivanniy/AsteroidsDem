using UnityEngine;
using Zenject;
using Views;
using Infrastructure.ScriptableObjects;
using Models;

namespace Infrastructure
{
    public class EnemyInstaller: MonoInstaller
    {
        [SerializeField] private UFOView ufoView;
        public EnemyRewardConfig RewardConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<IUfoFactory>().To<UfoFactory>().AsSingle().WithArguments(ufoView);
            Container.DeclareSignal<EnemySpawnRequestSignal>();
            Container.DeclareSignal<EnemyDestroyedSignal>();
            Container.Bind<ISpawnPointProvider>().To<SpawnPointProvider>().AsSingle();
            Container.Bind<EnemySpawnSystem>().AsSingle();
            Container.BindSignal<EnemySpawnRequestSignal>()
                .ToMethod<EnemySpawnSystem>(x =>x.OnSpawnRequested)
                .FromResolve();
            Container.BindInstance(RewardConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<RewardSystem>().AsSingle();
            Container.Bind<ScoreSystem>().AsSingle();
            Container.Bind<ITickable>().To<SpawnTimer>().AsSingle();
            //Container.Bind<SpawnTimer>().AsSingle().NonLazy();
        }
    }
}