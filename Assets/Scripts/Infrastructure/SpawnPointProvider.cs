using UnityEngine;

namespace Infrastructure
{
    public class SpawnPointProvider : ISpawnPointProvider
    {
        public static bool IsInsideScreen(Camera camera, Vector3 worldPoint)
        {
            Vector3 randomPoint = camera.WorldToViewportPoint(worldPoint);

            return randomPoint.z > 0 &&
                   randomPoint.x >= 0 && randomPoint.x <= 1 &&
                   randomPoint.y >= 0 && randomPoint.y <= 1;
        }

        public Vector2 GetRandomSpawnPoint()
        {
            Camera cam = Camera.main;
            Vector3 worldPoint;

            while (true)
            {
                Vector2 vp = new Vector2(
                    Random.Range(-0.2f, 1.2f),
                    Random.Range(-0.2f, 1.2f)
                );
                
                if (vp.x >= 0 && vp.x <= 1 &&
                    vp.y >= 0 && vp.y <= 1)
                    continue;

                float zDistance = -cam.transform.position.z;

                worldPoint = cam.ViewportToWorldPoint(new Vector3(
                    vp.x,
                    vp.y,
                    zDistance
                ));
                
                return worldPoint;
            }
        }
    }
}    