using System.Collections.Generic;
using Code.Infrastructure;
using Code.Ship.Health;
using UnityEngine;

namespace Code.Module.Weapon
{
    public class BulletService : IBulletService
    {
        private IHealthService _healthService;
        private List<Bullet> bullets = new List<Bullet>();

        public BulletService(IHealthService healthService)
        {
            _healthService = healthService;
        }

        public void Tick(float tick)
        {
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
            bullets.Add(bullet);
        }

        private void TickBullet(float tick, Bullet bullet)
        {
            bullet.Cooldown.Tick(tick);
        }

        private void MakeDamage(Bullet bullet)
        {
            _healthService.TakeDamage(bullet.Damage, bullet.Target);
            Debug.Log("Done " + bullet.Target.Health.GetTotal());
            Object.Destroy(bullet.UI);
        }
    }
}