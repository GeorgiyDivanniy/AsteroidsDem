using UnityEngine;
using Views;
using Zenject;

namespace Infrastructure
{
    public class UfoFactory : IUfoFactory
    {
        private readonly DiContainer _container; 
        private readonly UFOView _ufoPrefab;
        
        public UfoFactory(DiContainer container, UFOView ufoPrefab)
        {
            _container = container;
            _ufoPrefab = ufoPrefab;
        }

        public void CreateUfo(Transform position)
        {
            var ufo = _container.InstantiatePrefabForComponent<UFOView>(_ufoPrefab, position);
            ufo.Spawn(position);
            Debug.Log($"ИНОПРИЩЕЛЕНцы created: {ufo}");
        }
    }
}