using Helab.Simply;
using UnityEngine;

namespace Sample.Scripts
{
    [RequireComponent(typeof(TurnAroundWithDirection))]
    public class BulletCaster : MonoBehaviour
    {
        [SerializeField] private BulletLinePool bulletLinePool;
        
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
            }
            else if (Input.GetButtonDown("Fire3"))
            {
            }

        }
    }
}
