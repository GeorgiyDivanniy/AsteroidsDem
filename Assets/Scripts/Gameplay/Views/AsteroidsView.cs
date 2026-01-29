using UnityEngine;
using Zenject;

namespace Views
{
    public class AsteroidsView:PoolableView
    {
        [SerializeField] private PolygonCollider2D _collider;
        
        public void Awake()
        {
            _collider = GetComponent<PolygonCollider2D>();
        }
        public override void OnSpawned()
        {
            
        }
        public void Launch(Vector2 direction)
        {
            //    _rb.velocity = direction * _speed;
        }
        
        private void Update()
        {
            // _timer -= Time.deltaTime;
            // if (_timer <= 0f)
            //{
            RequestRelease();
            // }
        }
        
        public void OnCollisionEnter(Collision collision)
        {
            RequestRelease();
        }
    }
}