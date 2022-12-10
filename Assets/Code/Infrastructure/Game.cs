using System.Collections.Generic;
using System.Linq;
using Code.Module.Health;
using Code.Module.Weapon;
using Code.Ship;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Game
    {
        private Ship.Ship _ship;
        private List<Ship.Ship> _enemies = new List<Ship.Ship>();
        private ShipService _shipService = new ShipService();

        public void Init(GameObject shipUI, GameObject enemyUI, GameObject weaponUI)
        {
            _ship = new Ship.Ship();
            _ship.UI = shipUI;
            _ship.Health.Shield.Value = 90;
            //_ship.Health.Shield.IncCooldown.BaseCooldown = 2;
            var weapon = new Weapon();
            weapon.UI = weaponUI;
            weapon.Cooldown.Set(4);
            _ship.AddModule(weapon);
            _ship.AddModule(new SpeedupRestoreShieldModule());
            _ship.AddModule(new AdditionalShieldModule { Max = 50, Value = 45 });
            _ship.AddModule(new AdditionalHPModule());

            var enemy = new Ship.Ship();
            enemy.UI = enemyUI;
            _enemies.Add(enemy);

            //var damageModule = new WeaponService();
            //damageModule.Tick(1, _ship, new() { _ship });
            //Debug.Log("Damage");
        }

        public void Tick(float deltaTime)
        {
            _shipService.Tick(deltaTime, _ship, _enemies);
            var enemy = _enemies.First();
            //Debug.Log(enemy.Health.HP.GetTotalHP() + " " + enemy.Health.Shield.GetTotalShield());
            //Debug.Log(_ship.Health.HP.GetTotalHP() + " " + _ship.Health.Shield.Value + " " + _ship.Health.Shield.AdditionalShields.First().Value);
        }
    }
}