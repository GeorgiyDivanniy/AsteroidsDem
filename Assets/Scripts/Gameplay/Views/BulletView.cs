using UnityEngine;
using Views;

public class BulletView : PoolableView
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 2f;

    private Rigidbody2D _rb;
    private float _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void OnSpawned()
    {
        _timer = _lifeTime;
        _rb.velocity = Vector2.zero;
    }

    public void Launch(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            RequestRelease();
        }
    }
/*
    public override void OnDespawned()
    {
        _rb.velocity = Vector2.zero;
    }
    */
}