using UnityEngine;

namespace Infrastructure
{
    public interface IUfoFactory
    {
        void CreateUfo(Vector2 spawnPoint);
    }
}