using System;
using UnityEngine;

namespace Helab.Energy
{
    public class BezierCurveEnergy : AbstractKineticEnergy
    {
        public Vector3 StartPoint
        {
            get => _startPoint;
            set
            {
                _startPoint = value;
                _currentPosition = value;
            }
        }
        
        public Vector3 MidPoint { get; set; }
        
        public Vector3 EndPoint { get; set; }
        
        public float LifeTimeInSeconds { get; set; }
        
        private float _elapsedTimeInSeconds;

        private Vector3 _startPoint;

        private Vector3 _currentPosition;
        
        protected override void ResetKineticEnergy()
        {
            StartPoint = Vector3.zero;
            MidPoint = Vector3.zero;
            EndPoint = Vector3.zero;
            LifeTimeInSeconds = 0f;
            _elapsedTimeInSeconds = 0f;
            _currentPosition = Vector3.zero;
        }

        protected override void UpdateKineticEnergy(float deltaTime)
        {
            if (LifeTimeInSeconds <= _elapsedTimeInSeconds)
            {
                return;
            }

            _elapsedTimeInSeconds += deltaTime;
            var nextPosition = CalculateNextPosition(_elapsedTimeInSeconds);
            DeltaMovement = nextPosition - _currentPosition;
            _currentPosition = nextPosition;
        }

        private Vector3 CalculateNextPosition(float elapsedTimeInSeconds)
        {
            var t = elapsedTimeInSeconds / LifeTimeInSeconds;
            var p0 = Vector3.Lerp(StartPoint, MidPoint, t);
            var p1 = Vector3.Lerp(MidPoint, EndPoint, t);
            return Vector3.Lerp(p0, p1, t);
        }
    }
}
