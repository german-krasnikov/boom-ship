using UnityEngine;
using UnityEngine.Pool;

namespace Code.Logic
{
    public abstract class PoolHelper<T> where T : class
    {
        public IObjectPool<T> Pool;

        public PoolHelper(int maxPoolSize, bool collectionChecks = true)
        {
            Pool = new ObjectPool<T>(CreatePooledItem,
                OnTakeFromPool,
                OnReturnedToPool,
                OnDestroyPoolObject,
                collectionChecks,
                10,
                maxPoolSize);
        }

        public abstract void OnDestroyPoolObject(T obj);
        public abstract void OnReturnedToPool(T obj);
        public abstract void OnTakeFromPool(T obj);
        public abstract T CreatePooledItem();
    }
}