using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class EnemySpawnSystem
    {
        private readonly ISpawnPointProvider _spawnPointProvider;
        private readonly IUfoFactory _ufoFactory;

        public EnemySpawnSystem(ISpawnPointProvider spawnPointProvider, IUfoFactory ufoFactory)
        {
            _spawnPointProvider = spawnPointProvider;
            _ufoFactory = ufoFactory;
        }

        public void OnSpawnRequested()
        {
            Vector2 spawnPoint = _spawnPointProvider.GetRandomSpawnPoint();
            _ufoFactory.CreateUfo(spawnPoint);
        }
    }
}