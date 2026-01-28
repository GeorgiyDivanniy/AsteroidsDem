using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (!_subscribers.TryGetValue(type, out var list))
            {
                list = new List<Delegate>();
                _subscribers[type] = list;
            }

            list.Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                list.Remove(handler);
                if (list.Count == 0)
                    _subscribers.Remove(type);
            }
        }

        public void Publish<T>(T evt)
        {
            var type = typeof(T);
            if (_subscribers.TryGetValue(type, out var list))
            {
                var snapshot = list.ToArray();
                for (int i = 0; i < snapshot.Length; i++)
                {
                    try
                    {
                        ((Action<T>)snapshot[i])?.Invoke(evt);
                    }
                    catch (Exception ex)
                    {
                        UnityEngine.Debug.LogException(ex);
                    }
                }
            }
        }
    }
}