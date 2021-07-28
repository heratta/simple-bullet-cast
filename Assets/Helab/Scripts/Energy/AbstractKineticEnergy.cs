using Helab.ObjectPool;
using Helab.Time;
using UnityEngine;

namespace Helab.Energy
{
    public abstract class AbstractKineticEnergy : MonoBehaviour, IResettable
    {
        public bool IsEnabledUpdate { get; set; } = true;
        
        public Vector3 DeltaMovement { get; protected set; }
        
        public void ResetInternalState()
        {
            DeltaMovement = Vector3.zero;
            ResetKineticEnergy();
        }

        private void Update()
        {
            DeltaMovement = Vector3.zero;
            if (IsEnabledUpdate)
            {
                UpdateKineticEnergy(AppTime.DeltaTime);
            }
        }

        protected abstract void ResetKineticEnergy();
        
        protected abstract void UpdateKineticEnergy(float deltaTime);
    }
}
