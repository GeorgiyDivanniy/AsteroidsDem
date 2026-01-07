using System;
using Zenject;
using Infrastructure.ScriptableObjects;
using Models;

namespace Infrastructure
{
    public class RewardSystem: IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly EnemyRewardConfig _rewardConfig;
        private readonly ScoreSystem _scoreSystem;

        public RewardSystem(
            SignalBus signalBus,
            EnemyRewardConfig rewardConfig,
            ScoreSystem scoreSystem)
        {
            _signalBus = signalBus;
            _rewardConfig = rewardConfig;
            _scoreSystem = scoreSystem;
        }

        public void Initialize()
        {
            _rewardConfig.Initialize();
            _signalBus.Subscribe<EnemyDestroyedSignal>(OnEnemyDestroyed);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyDestroyedSignal>(OnEnemyDestroyed);
        }

        private void OnEnemyDestroyed(EnemyDestroyedSignal signal)
        {
            int score = _rewardConfig.GetScore(signal.EnemyType);
            _scoreSystem.Add(score);
        }
    } 
}