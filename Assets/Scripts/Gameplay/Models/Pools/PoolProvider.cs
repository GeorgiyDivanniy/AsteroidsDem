using UnityEngine;
using Zenject;
using Views;
using System.Collections.Generic;

namespace Models.Pools
{
    public class PoolProvider<T>: IObjectProvider<T> where T: PoolableView
    {
        private readonly DiContainer _container;
        private readonly T _prefab;
        private readonly Stack<T> _pool = new();

        public PoolProvider(DiContainer container, T prefab, int initialSize)
        {
            _container = container;
            _prefab = prefab;

            for (int i = 0; i < initialSize; i++)
            {
                var obj = CreateNew();
                obj.gameObject.SetActive(false);
                _pool.Push(obj);
            }
        }

        public T Get(Vector3 position)
        {
            var obj = _pool.Count > 0 ? _pool.Pop() : CreateNew();

            obj.transform.position = position;
            obj.gameObject.SetActive(true);
            obj.OnSpawned();
            obj.OnReleaseRequested += view => Release((T)view);

            return obj;
        }

        public void Release(T obj)
        {
            obj.Despawn();
            //obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }

        private T CreateNew()
        {
            return _container.InstantiatePrefabForComponent<T>(
                _prefab,
                Vector3.zero,
                Quaternion.identity,
                null
            );
        }
    }
}