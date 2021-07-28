using System;
using System.Collections.Generic;
using System.Linq;
using Helab.ObjectPool;
using UnityEngine;

namespace Helab.Energy
{
    public class DistanceMonitor : MonoBehaviour, IResettable
    {
        private Action _onCompleted;

        private readonly List<AbstractKineticEnergy> _kineticEnergies = new List<AbstractKineticEnergy>();
        
        private float _remainingDistanceInMeters;

        public void StartMonitor(float limitDistanceInMeters, Action onCompleted, IEnumerable<AbstractKineticEnergy> kineticEnergies)
        {
            _remainingDistanceInMeters = limitDistanceInMeters;
            _onCompleted = onCompleted;
            
            _kineticEnergies.Clear();
            _kineticEnergies.AddRange(kineticEnergies);
        }

        public void ResetInternalState()
        {
            _onCompleted = null;
            _kineticEnergies.Clear();
            _remainingDistanceInMeters = 0f;
        }

        private void LateUpdate()
        {
            if (_remainingDistanceInMeters <= 0f)
            {
                return;
            }
            
            var deltaMovement = KineticEnergyUtil.AggregateDeltaMovement(_kineticEnergies);
            _remainingDistanceInMeters -= deltaMovement.magnitude;
            if (_remainingDistanceInMeters <= 0f)
            {
                _onCompleted?.Invoke();
            }
        }
    }
}
