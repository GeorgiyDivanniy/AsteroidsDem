using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using Views;
using Models.Pools;

namespace Infrastructure
{
    public class UniversalFactory
    {
        private readonly Dictionary<Type, object> _providers = new();

        public void Register<T>(IObjectProvider<T> provider)
            where T : PoolableView
        {
            _providers[typeof(T)] = provider;
        }
        
        public T Create<T>(Vector3 position)
            where T : PoolableView
        {
            var provider = (IObjectProvider<T>)_providers[typeof(T)];
            return provider.Get(position);
        }
        
        public void Release<T>(T obj)
            where T : PoolableView
        {
            var provider = (IObjectProvider<T>)_providers[typeof(T)];
            provider.Release(obj);
        }
    }
}