using UnityEngine;
using Zenject;
using Infrastructure.ScriptableObjects;

namespace Infrastructure
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Die()
        {
            _signalBus.Fire(new EnemyDestroyedSignal(_enemyType));
            
            gameObject.SetActive(false);
        }
    }
}