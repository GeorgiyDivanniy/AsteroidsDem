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

        public void CreateUfo(Vector2 position)
        {
            /*
            var ufo = _container.InstantiatePrefabForComponent<UFOView>(_ufoPrefab, spawnPoint);
            ufo.Spawn(spawnPoint);
            */
            Object.Instantiate(_ufoPrefab, new Vector3(position.x,position.y,0f), Quaternion.identity);
            Debug.Log($"ИНОПРИЩЕЛЕНцы created:");
        }
    }
}