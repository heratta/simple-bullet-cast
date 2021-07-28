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
    [RequireComponent(typeof(DistanceMonitor))]
    [RequireComponent(typeof(SetRendererColor))]
    [RequireComponent(typeof(SimpleSpinning))]
    public class BulletLine : PooledMonoBehaviour
    {
        private BulletEnergy _bulletEnergy;
        private DistanceMonitor _distanceMonitor;
        private SetRendererColor _setRendererColor;
        private SimpleSpinning _simpleSpinning;
        private Action<BulletLine> _onFinished;
        
        public void Initialize(Action<BulletLine> onFinished)
        {
            _bulletEnergy = GetComponent<BulletEnergy>();
            _distanceMonitor = GetComponent<DistanceMonitor>();
            _setRendererColor = GetComponent<SetRendererColor>();
            _simpleSpinning = GetComponent<SimpleSpinning>();
            _onFinished = onFinished;
        }

        public void Configure(Vector3 startPosition, Vector3 direction)
        {
            transform.position = startPosition;
            _bulletEnergy.BulletDirection = direction;
            _bulletEnergy.BulletSpeed = 4f;
            _distanceMonitor.StartMonitor(10f, Finish, new List<AbstractKineticEnergy> { _bulletEnergy });
            _setRendererColor.RefreshWithRandom();
            _simpleSpinning.RefreshRotateAxisWithRandom();
        }

        private void Finish()
        {
            _onFinished?.Invoke(this);
        }
    }
}
