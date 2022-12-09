using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Ship.Health;

namespace Code.Module.Weapon
{
    public class WeaponService
    {
        public void Tick(float tick, Ship.Ship ship, List<Ship.Ship> enemies, HealthService healthService)
        {
            foreach (var weapon in ship.Weapons())
            {
                TickWeapon(tick, ship, weapon);
                if (weapon.CanShot())
                {
                    var enemy = FindEnemyForShot(enemies, weapon);
                    if (enemy != null)
                        Shot(enemy, weapon, healthService);
                }
            }
        }

        private void TickWeapon(float tick, Ship.Ship ship, Weapon weapon)
        {
            weapon.Cooldown.TickWithSpeedUp(tick, ship.SpeedupReloadWeapons().Sum(it => it.SpeedupPercent));
        }

        private Ship.Ship FindEnemyForShot(List<Ship.Ship> enemies, Weapon weapon) => enemies.FirstOrDefault();

        private void Shot(Ship.Ship enemy, Weapon weapon, HealthService healthService)
        {
            healthService.TakeDamage(weapon.Damage, enemy);
            weapon.Cooldown.Reset();
            //enemy.Shot();
        }
    }
}