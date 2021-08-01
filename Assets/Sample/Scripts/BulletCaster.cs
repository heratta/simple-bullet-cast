using Helab.Simply;
using UnityEngine;

namespace Sample.Scripts
{
    [RequireComponent(typeof(TurnAroundWithDirection))]
    public class BulletCaster : MonoBehaviour
    {
        [SerializeField] private BulletLinePool bulletLinePool;
        [SerializeField] private BulletParabolicPool bulletParabolicPool;
        [SerializeField] private BulletCurvePool bulletCurvePool;
        
        private TurnAroundWithDirection _turnAround;
        
        private void Awake()
        {
            _turnAround = GetComponent<TurnAroundWithDirection>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var bullet = bulletLinePool.GetObject();
                var direction = _turnAround.TargetDirection.normalized;
                var startPosition = transform.position + direction + Vector3.up;
                bullet.Configure(startPosition, direction);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                var bullet = bulletParabolicPool.GetObject();
                var direction = _turnAround.TargetDirection.normalized;
                var startPosition = transform.position + direction + Vector3.up;
                bullet.Configure(startPosition, direction, 65f);
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                var bullet = bulletCurvePool.GetObject();
                var position = transform.position;
                var direction = _turnAround.TargetDirection.normalized;
                var startPosition = position + direction + Vector3.up;
                var endPosition = position + direction * 5f;
                endPosition.y = 0f;
                bullet.Configure(startPosition, endPosition, 2.5f);
            }
        }
    }
}
