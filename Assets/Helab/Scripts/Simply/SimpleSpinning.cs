using Helab.Time;
using UnityEngine;

namespace Helab.Simply
{
    public class SimpleSpinning : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed = 360f;
        
        private float _rotateAngle;
        
        private Vector3 _rotateAxis;
        
        public void RefreshRotateAxisWithRandom()
        {
            _rotateAxis = Random.insideUnitSphere;
        }

        private void OnEnable()
        {
            _rotateAngle = 0f;
            _rotateAxis = Vector3.up;
        }

        private void Update()
        {
            _rotateAngle += rotateSpeed * AppTime.DeltaTime;
            transform.rotation = Quaternion.AngleAxis(_rotateAngle, _rotateAxis);
        }
    }
}
