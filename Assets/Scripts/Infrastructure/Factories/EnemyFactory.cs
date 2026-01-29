using UnityEngine;
using Views;
using Zenject;

namespace Infrastructure
{
    public class EnemyFactory
    {
        private readonly UniversalFactory _factory;
        
        public EnemyFactory(UniversalFactory factory)
        {
            _factory = factory;
        }

        public UFOView CreateUfo(Vector3 position)
        {
            return _factory.Create<UFOView>(position);
        }
        
        //asteroids same
    }
}