using UnityEngine;
using Views;

public class BeamView : PoolableView
{
    [SerializeField] private float _duration = 0.5f;

    public void Launch(Vector2 direction)
    {
        Debug.Log("Launching Beam View");
        transform.up = direction;
        Destroy(gameObject, _duration);
    }
}

