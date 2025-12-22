using UnityEngine;
using Zenject;
using Models;
using Views;
using ViewModels;

namespace Infrastructure
{
    public class MovementInstaller : MonoInstaller
    {
        [Header("Scene References")]
        [SerializeField] private CharacterMovement characterMovement;
        [SerializeField] private ShipView shipView;
    
        [Header("Movement settings")]
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float acceleration = 5f;
        [SerializeField] private float braking = 1f;
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<ShipMovementModel>().FromInstance(new ShipMovementModel(maxSpeed, acceleration, braking)).AsSingle();
            Container.Bind<ShipModel>().AsSingle();
        
            Container.Bind<ShipView>().FromInstance(shipView).AsSingle();
            Container.Bind<CharacterMovement>().FromInstance(characterMovement).AsSingle();
        
            Container.BindInterfacesTo<ShipPresenter>().AsSingle();
            Container.DeclareSignal<ExitedScreenBoundsSignal>();
            Container.BindInterfacesTo<TeleportHandler>().AsSingle();
            
        }
    }
}
