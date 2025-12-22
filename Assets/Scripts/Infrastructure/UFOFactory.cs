using UnityEngine;
using Views;
using Zenject;

namespace Infrastructure
{
    public class UFOFactory : IUFOFactory
    {
        private readonly DiContainer _container;
        [SerializeField] private readonly UFOView _UFOPrefab;
        
        public UFOFactory(DiContainer container, UFOView ufoPrefab)
        {
            _container = container;
            _UFOPrefab = ufoPrefab;
        }

        public void CreateUFO(Transform position)
        {
            var UFO = _container.InstantiatePrefabForComponent<UFOView>(_UFOPrefab, position);
            UFO.Spawn(position);
        }
    }
}