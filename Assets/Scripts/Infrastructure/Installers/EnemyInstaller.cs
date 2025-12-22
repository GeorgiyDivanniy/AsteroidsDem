using UnityEngine;
using Zenject;
using Views;
namespace Infrastructure
{
    public class EnemyInstaller: MonoInstaller
    {
        [SerializeField] private UFOView ufoView;
        public override void InstallBindings()
        {
            Container.Bind<IUfoFactory>().To<UfoFactory>().AsSingle().WithArguments(ufoView);
        }
    }
}