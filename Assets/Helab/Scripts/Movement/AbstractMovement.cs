using System;
using System.Linq;
using Helab.Energy;
using UnityEngine;

namespace Helab.Movement
{
    public abstract  class AbstractMovement : MonoBehaviour
    {
        private AbstractKineticEnergy[] _kineticEnergies;

        private void Start()
        {
            _kineticEnergies = GetComponents<AbstractKineticEnergy>();
            StartMovement();
        }
        
        private void Update()
        {
            var deltaMovement = KineticEnergyUtil.AggregateDeltaMovement(_kineticEnergies);
            UpdateMovement(deltaMovement);
        }

        protected abstract void StartMovement();
        
        protected abstract void UpdateMovement(Vector3 deltaMovement);
    }
}
