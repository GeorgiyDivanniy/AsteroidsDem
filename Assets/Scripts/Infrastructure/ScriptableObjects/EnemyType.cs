using UnityEngine;

namespace Infrastructure.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game/Enemy Type")]
    public class EnemyType: ScriptableObject
    {
        public string id;
    }
}