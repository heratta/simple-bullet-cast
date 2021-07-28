using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helab.Energy
{
    public static class KineticEnergyUtil
    {
        public static Vector3 AggregateDeltaMovement(IEnumerable<AbstractKineticEnergy> kineticEnergies)
        {
            return kineticEnergies.Aggregate(
                Vector3.zero,
                (current, ke) => current + ke.DeltaMovement);
        }
    }
}
