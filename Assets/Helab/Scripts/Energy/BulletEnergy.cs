using UnityEngine;

namespace Helab.Energy
{
    public class BulletEnergy : AbstractKineticEnergy
    {
        public float BulletSpeed { get; set; }
        
        public Vector3 BulletDirection { get; set; }
        
        protected override void ResetKineticEnergy()
        {
            BulletDirection = Vector3.zero;
            BulletSpeed = 0f;
        }

        protected override void UpdateKineticEnergy(float deltaTime)
        {
            DeltaMovement = BulletDirection * (BulletSpeed * deltaTime);
        }
    }
}
