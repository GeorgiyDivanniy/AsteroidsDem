using UnityEngine;

namespace Infrastructure
{
    public interface ISpawnPointProvider
    {
        Vector2 GetRandomSpawnPoint();
    }
}