using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetManagement;
using Code.Logic;
using Code.Ship.Health;
using UnityEngine;

namespace Code.Module.Weapon
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
                    var enemy = FindEnemyForShot(enemies, weapon);
                    if (enemy != null)
                        Shot(enemy, ship, weapon);
                }
            }
        }

        private void TickWeapon(float tick, Ship.Ship ship, Weapon weapon)
        {
            weapon.Cooldown.TickWithSpeedUp(tick, ship.SpeedupReloadWeapons().Sum(it => it.SpeedupPercent));
        }

        private Ship.Ship FindEnemyForShot(List<Ship.Ship> enemies, Weapon weapon) => enemies.FirstOrDefault();

        private void Shot(Ship.Ship enemy, Ship.Ship ship, Weapon weapon)
        {
            var bullet = new Bullet
            {
                Damage = weapon.Damage,
                Target = enemy,
            };
            bullet.Cooldown.Set(weapon.BulletTime);
            _bulletService.AddBullet(bullet);
            weapon.Cooldown.Reset();
            Debug.Log("Shot " + enemy.Health.GetTotal());
            var bulletUI = _assetProvider.Instantiate(AssetPath.BulletPath, weapon.UI.transform.position);
            bulletUI.GetComponent<BulletUI>().StartCoroutine(
                MoveOverSeconds.Move(bulletUI, enemy.UI, bullet.Cooldown.Current));
            bullet.UI = bulletUI;
        }
    }
}