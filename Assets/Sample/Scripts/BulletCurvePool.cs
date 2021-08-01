using Helab.ObjectPool;
using UnityEngine;

namespace Sample.Scripts
{
    public class BulletCurvePool : PoolOf<BulletCurve>
    {
        [SerializeField] private BulletCurve originalBullet;
        
        private void Awake()
        {
            CreatePool(() =>
            {
                var bullet = Instantiate(originalBullet, transform, false);
                bullet.Initialize(ReleaseObject);
                return bullet;
            }, 10);
        }
    }
}
