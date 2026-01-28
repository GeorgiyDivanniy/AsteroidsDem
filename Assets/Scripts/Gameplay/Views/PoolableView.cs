using UnityEngine;

namespace Views
{
    public abstract class PoolableView: MonoBehaviour
    {
        public System.Action<PoolableView> OnReleaseRequested;
        
        public virtual void OnSpawned() { }
        public virtual void OnDespawned() { }
    }
}