using System;
using UnityEngine;

namespace Views
{
    public class UFOView: MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D _collider;
        public void Spawn(Transform  position)
        {
            GetComponent<Transform>().SetPositionAndRotation(position.position, position.rotation);
        }

        public void Awake()
        {
            _collider = GetComponent<PolygonCollider2D>();
        }

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(this.gameObject);
        }
    }
}