using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    public void Launch(Vector2 direction)
    {
        Debug.Log("ПИЗДААААААААААААА");
        GetComponent<Rigidbody2D>().velocity = direction * _speed;
        Destroy(gameObject, 2f);
    }
}
