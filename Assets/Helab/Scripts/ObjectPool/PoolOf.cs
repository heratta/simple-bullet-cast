using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Helab.ObjectPool
{
    public class PoolOf<T> : MonoBehaviour where T : PooledMonoBehaviour
    {
        private IObjectPool<T> _pool;
        
        protected void CreatePool(Func<T> createFunc, int size)
        {
            _pool = new ObjectPool<T>(
                createFunc,
                OnGetObject,
                OnReleaseObject,
                OnDestroyObject,
                true,
                size,
                size);
        }

        public T GetObject()
        {
            return _pool.Get();
        }
        
        public void ReleaseObject(T obj)
        {
            _pool.Release(obj);
        }

        private static void OnGetObject(T obj)
        {
            obj.gameObject.SetActive(true);
        }

        private static void OnReleaseObject(T obj)
        {
            obj.ResetInternalState();
            obj.gameObject.SetActive(false);
        }
        
        private static void OnDestroyObject(T obj)
        {
            Destroy(obj.gameObject);
        }
    }
}
