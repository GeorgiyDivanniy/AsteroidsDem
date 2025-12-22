using UnityEngine;
using Zenject;
using Views;
using ViewModels;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Scene references")]
        [SerializeField] private ShipHUDView shipHudView;

        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            
            Container.Bind<ShipHUDView>().FromInstance(shipHudView).AsSingle();
            
            Container.BindInterfacesTo<ShipHUDViewModel>().AsSingle();
            Container.Bind<ViewModels.IHUDView>().To<ShipHUDView>().FromInstance(shipHudView);
        }
    }
}

