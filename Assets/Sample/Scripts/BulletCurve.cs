using System;
using Helab.Energy;
using Helab.Movement;
using Helab.ObjectPool;
using Helab.Simply;
using Helab.Time;
using UnityEngine;

namespace Sample.Scripts
{
    [RequireComponent(typeof(StandardMovement))]
    [RequireComponent(typeof(BezierCurveEnergy))]
    [RequireComponent(typeof(AppTimer))]
    [RequireComponent(typeof(SetRendererColor))]
    [RequireComponent(typeof(SimpleSpinning))]
    public class BulletCurve : PooledMonoBehaviour
    {
        private BezierCurveEnergy _curveEnergy;
        private AppTimer _timer;
        private SetRendererColor _setRendererColor;
        private SimpleSpinning _simpleSpinning;
        private Action<BulletCurve> _onFinished;
        
        public void Initialize(Action<BulletCurve> onFinished)
        {
            _curveEnergy = GetComponent<BezierCurveEnergy>();
            _timer = GetComponent<AppTimer>();
            _setRendererColor = GetComponent<SetRendererColor>();
            _simpleSpinning = GetComponent<SimpleSpinning>();
            _onFinished = onFinished;
        }

        public void Configure(Vector3 startPosition, Vector3 endPosition, float durationInSeconds)
        {
            transform.position = startPosition;
            
            var startToEnd = endPosition - startPosition;
            _curveEnergy.LifeTimeInSeconds = durationInSeconds;
            _curveEnergy.StartPoint = startPosition;
            _curveEnergy.MidPoint = startPosition + startToEnd * 0.5f + Vector3.up * 10f;
            _curveEnergy.EndPoint = endPosition;
            
            _timer.StartTimer(durationInSeconds, Finish);
            _setRendererColor.RefreshWithRandom();
            _simpleSpinning.RefreshRotateAxisWithRandom();
        }

        private void Finish()
        {
            _onFinished?.Invoke(this);
        }
    }
}
