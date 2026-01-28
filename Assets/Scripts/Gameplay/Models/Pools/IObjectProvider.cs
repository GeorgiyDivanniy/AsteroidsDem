using UnityEngine;
using Views;

namespace Models.Pools
{
    public interface IObjectProvider<T> where T : PoolableView
    {
        T Get(Vector3 position);
        void Release(T obj);
    }
}