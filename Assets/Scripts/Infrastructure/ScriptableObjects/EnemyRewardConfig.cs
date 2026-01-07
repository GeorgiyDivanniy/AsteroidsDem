using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Enemy Reward Config")]
    
    public class EnemyRewardConfig: ScriptableObject
    {
        [System.Serializable]
        public class Entry
        {
            public EnemyType EnemyType;
            public int Score;
        }

        public List<Entry> Rewards = new();

        private Dictionary<EnemyType, int> _cache;

        public void Initialize()
        {
            _cache = new Dictionary<EnemyType, int>();
            foreach (var entry in Rewards)
            {
                _cache[entry.EnemyType] = entry.Score;
            }
        }

        public int GetScore(EnemyType type)
        {
            return _cache.TryGetValue(type, out var score) ? score : 0;
        }
    } 
}
