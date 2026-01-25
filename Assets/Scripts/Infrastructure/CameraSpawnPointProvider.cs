using UnityEngine;

namespace Infrastructure
{
    public class CameraSpawnPointProvider: ISpawnPointProvider
    {
        public Vector2 GetRandomSpawnPoint()
        {
            Vector2 screenPoint = new Vector2(
                Random.Range(0f, Screen.width),
                Random.Range(0f,Screen.height)
            );
            
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            return new Vector2(worldPoint.x, worldPoint.y);
        }
    }
}