using UnityEngine;

public class BeamView : MonoBehaviour
{
    [SerializeField] private float _duration = 0.5f;

    public void Launch(Vector2 direction)
    {
        Debug.Log("Launching Beam View");
        transform.up = direction;
        Destroy(gameObject, _duration);
    }
}

