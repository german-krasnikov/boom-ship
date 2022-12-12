using Code.Infrastructure.AssetManagement;
using Code.Logic;
using Code.Ship.Health;
using Code.World;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletService : IBulletService
    {
        private readonly IHealthService _healthService;
        private readonly World.World _world;
        private BulletPool _pool;

        public BulletService(IHealthService healthService, IWorldService worldService, IAssetProvider assetProvider)
        {
            _healthService = healthService;
            _world = worldService.World;
            _pool = new BulletPool(assetProvider);
        }

        public void Tick(float tick)
        {
            var bullets = _world.Bullets;
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var bullet = bullets[i];
                TickBullet(tick, bullet);

                if (bullet.Done())
                {
                    MakeDamage(bullet);
                    bullets.RemoveAt(i);
                }
            }
        }

        public void AddBullet(Ship.Ship enemy, Weapon.Weapon weapon)
        {
            var bullet = new Bullet
            {
                Damage = weapon.Damage,
                Target = enemy,
            };
            bullet.Cooldown.Set(weapon.BulletTime);
            Debug.Log($"Shot to {enemy.UI.name} {enemy.Health.GetTotal()} {bullet.Cooldown.Current}");
            var bulletUI = _pool.Get(weapon.UI.BulletSpawnPoint.transform.position);
            bulletUI.GetComponent<BulletUI>().StartCoroutine(
                MoveOverSeconds.Move(bulletUI.gameObject, enemy.UI.gameObject, bullet.Cooldown.Current));
            bullet.UI = bulletUI;

            _world.Bullets.Add(bullet);
        }

        private void TickBullet(float tick, Bullet bullet)
        {
            //Debug.Log($"{bullet.Cooldown.Current} {tick}");
            bullet.Cooldown.Tick(tick);
        }

        private void MakeDamage(Bullet bullet)
        {
            _healthService.TakeDamage(bullet.Damage, bullet.Target);
            Debug.Log($"MakeDamage {bullet.Damage} {bullet.Target} {bullet.Target.Health.GetTotal()}");
            _pool.Pool.Release(bullet.UI);
        }
    }
}