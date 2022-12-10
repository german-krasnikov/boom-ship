using System.Collections.Generic;
using Code.Ship.Health;
using UnityEngine;

namespace Code.Module.Weapon
{
    public class BulletService
    {
        public List<Bullet> bullets = new List<Bullet>();

        public void Tick(float tick, HealthService healthService)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                var bullet = bullets[i];
                TickBullet(tick, bullet);

                if (bullet.Done())
                {
                    MakeDamage(bullet, healthService);
                    bullets.RemoveAt(i);
                }
            }
        }

        private void TickBullet(float tick, Bullet bullet)
        {
            bullet.Cooldown.Tick(tick);
        }

        private void MakeDamage(Bullet bullet, HealthService healthService)
        {
            healthService.TakeDamage(bullet.Damage, bullet.Target);
            Debug.Log("Done " + bullet.Target.Health.GetTotal());
            Object.Destroy(bullet.UI);
        }
    }
}