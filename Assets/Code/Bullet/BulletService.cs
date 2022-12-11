using System.Collections.Generic;
using Code.Ship.Health;
using Code.World;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletService : IBulletService
    {
        private readonly IHealthService _healthService;
        private readonly World.World _world;

        public BulletService(IHealthService healthService, IWorldService worldService)
        {
            _healthService = healthService;
            _world = worldService.World;
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

        public void AddBullet(Bullet bullet)
        {
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
            Object.Destroy(bullet.UI);
        }
    }
}