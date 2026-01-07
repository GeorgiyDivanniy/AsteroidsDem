using Infrastructure.ScriptableObjects;

namespace Infrastructure
{
    public class EnemyDestroyedSignal
    {
        public EnemyType EnemyType;

        public EnemyDestroyedSignal(EnemyType enemyType)
        {
            EnemyType = enemyType;
        }
    }
}