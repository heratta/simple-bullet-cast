using System.Collections.Generic;
using UnityEngine;

namespace Helab.ObjectPool
{
    public class PooledMonoBehaviour : MonoBehaviour
    {
        private readonly List<IResettable> _resettableComponents = new List<IResettable>();
        
        private void Awake()
        {
            var components = GetComponents<MonoBehaviour>();
            foreach (var c in components)
            {
                if (c is IResettable resettable)
                {
                    _resettableComponents.Add(resettable);
                }
            }
        }

        public void ResetInternalState()
        {
            foreach (var r in  _resettableComponents)
            {
                r.ResetInternalState();
            }
        }
    }
}
