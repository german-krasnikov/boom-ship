using System.Collections.Generic;
using System.Linq;
using Code.Bullet;
using Code.Infrastructure.AssetManagement;
using Code.Logic;
using UnityEngine;

namespace Code.Weapon
{
    public class WeaponService : IWeaponService
    {
        private IAssetProvider _assetProvider;
        private IBulletService _bulletService;

        public WeaponService(IAssetProvider assetProvider, IBulletService bulletService)
        {
            _assetProvider = assetProvider;
            _bulletService = bulletService;
        }

        public void Tick(float tick, Ship.Ship ship, List<Ship.Ship> enemies)
        {
            foreach (var weapon in ship.Weapons())
            {
                TickWeapon(tick, ship, weapon);
                if (weapon.CanShot())
                {
                    var enemy = FindEnemyForShot(enemies);
                    if (enemy != null)
                        Shot(enemy, weapon);
                }
            }
        }

        private void TickWeapon(float tick, Ship.Ship ship, Weapon weapon)
        {
            weapon.Cooldown.TickWithSpeedUp(tick, ship.SpeedupReloadWeapons().Sum(it => it.SpeedupPercent));
        }

        private Ship.Ship FindEnemyForShot(List<Ship.Ship> enemies) => enemies.FirstOrDefault();

        private void Shot(Ship.Ship enemy, Weapon weapon)
        {
            weapon.Cooldown.Reset();
            _bulletService.AddBullet(enemy, weapon);
        }
    }
}