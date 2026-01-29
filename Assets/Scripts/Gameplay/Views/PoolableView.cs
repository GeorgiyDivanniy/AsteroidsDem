using UnityEngine;

namespace Views
{
    public abstract class PoolableView: MonoBehaviour
    {
        public System.Action<PoolableView> OnReleaseRequested;

        public virtual void OnSpawned()
        {
            gameObject.SetActive(true);
        }
       // public virtual void OnDespawned() { }

        protected void RequestRelease()
        {
            OnReleaseRequested?.Invoke(this);
        }
        public virtual void Despawn()
        {
            gameObject.SetActive(false);
        }
    }
}