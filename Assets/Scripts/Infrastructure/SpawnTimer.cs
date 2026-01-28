using UnityEngine;
using Zenject;
namespace Infrastructure
{
    public class SpawnTimer:ITickable
    {
        private readonly SignalBus _signalBus;

        public SpawnTimer(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void SpawnEnemy()
        {
            //_signalBus.Fire<EnemySpawnRequestSignal>();
        }

        public void Tick()
        {
            //SpawnEnemy();
            //Debug.Log("Братки едут");
        }
    }
}