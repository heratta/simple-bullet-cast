using Helab.ObjectPool;
using UnityEngine;

namespace Sample.Scripts
{
    public class BulletLinePool : PoolOf<BulletLine>
    {
        [SerializeField] private BulletLine originalBullet;
        
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
