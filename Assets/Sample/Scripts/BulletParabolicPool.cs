using Helab.ObjectPool;
using UnityEngine;

namespace Sample.Scripts
{
    public class BulletParabolicPool : PoolOf<BulletParabolic>
    {
        [SerializeField] private BulletParabolic originalBullet;
        
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
