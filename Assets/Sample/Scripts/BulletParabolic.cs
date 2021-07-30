using System;
using System.Collections.Generic;
using Helab.Energy;
using Helab.Movement;
using Helab.ObjectPool;
using Helab.Simply;
using UnityEngine;

namespace Sample.Scripts
{
    [RequireComponent(typeof(StandardMovement))]
    [RequireComponent(typeof(BulletEnergy))]
    [RequireComponent(typeof(GravityEnergy))]
    [RequireComponent(typeof(DistanceMonitor))]
    [RequireComponent(typeof(SetRendererColor))]
    [RequireComponent(typeof(SimpleSpinning))]
    public class BulletParabolic : PooledMonoBehaviour
    {
        private BulletEnergy _bulletEnergy;
        private DistanceMonitor _distanceMonitor;
        private SetRendererColor _setRendererColor;
        private SimpleSpinning _simpleSpinning;
        private Action<BulletParabolic> _onFinished;
        
        public void Initialize(Action<BulletParabolic> onFinished)
        {
            _bulletEnergy = GetComponent<BulletEnergy>();
            _distanceMonitor = GetComponent<DistanceMonitor>();
            _setRendererColor = GetComponent<SetRendererColor>();
            _simpleSpinning = GetComponent<SimpleSpinning>();
            _onFinished = onFinished;
        }

        public void Configure(Vector3 startPosition, Vector3 direction, float angle)
        {
            transform.position = startPosition;
            _bulletEnergy.BulletDirection = CalcBulletDirection(direction, angle);
            _bulletEnergy.BulletSpeed = 10f;
            _distanceMonitor.StartMonitor(20f, Finish, new List<AbstractKineticEnergy> { _bulletEnergy });
            _setRendererColor.RefreshWithRandom();
            _simpleSpinning.RefreshRotateAxisWithRandom();
        }

        private static Vector3 CalcBulletDirection(Vector3 direction, float angle)
        {
            var right = Vector3.Cross(Vector3.up, direction);
            var rotate = Quaternion.AngleAxis(-angle, right);
            return rotate * direction;
        }

        private void Finish()
        {
            _onFinished?.Invoke(this);
        }
    }
}
