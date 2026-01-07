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
            Container.DeclareSignal<EnemyDestroyedSignal>();
            Container.BindInstance(RewardConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<RewardSystem>().AsSingle();
            Container.Bind<ScoreSystem>().AsSingle();
        }
    }
}