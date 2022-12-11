using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetManagement;
using Code.Module.Health;
using Code.Module.Weapon;
using Code.Ship;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        private Ship.Ship _ship;
        private List<Ship.Ship> _enemies = new List<Ship.Ship>();
        private IShipService _shipService;

        public GameLoopState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            _shipService = _services.Single<IShipService>();
            Init();
        }

        public void Tick(float deltaTime)
        {
            _shipService.Tick(deltaTime, _ship, _enemies);
            _shipService.Tick(deltaTime, _enemies.First(), new() { _ship });
            //var enemy = _enemies.First();
            //Debug.Log(enemy.Health.HP.GetTotalHP() + " " + enemy.Health.Shield.GetTotalShield());
            //Debug.Log(_ship.Health.HP.GetTotalHP() + " " + _ship.Health.Shield.Value + " " + _ship.Health.Shield.AdditionalShields.First().Value);
        }

        public void Exit()
        {
        }

        public void Init()
        {
            var assets = AllServices.Container.Single<IAssetProvider>();
            var shipUI = assets.Instantiate(AssetPath.ShipPath);
            var enemyUI = assets.Instantiate(AssetPath.ShipPath, new Vector3(10, 0, 10));

            _ship = new Ship.Ship();
            _ship.UI = shipUI;
            _ship.Health.Shield.Value = 90;
            //_ship.Health.Shield.IncCooldown.BaseCooldown = 2;
            _ship.AddModule(CreateWeapon(shipUI, enemyUI, assets, "RocketLauncher5", 0, 4));
            _ship.AddModule(CreateWeapon(shipUI, enemyUI, assets, "Gun4", 1, 0.5f));
            _ship.AddModule(new SpeedupRestoreShieldModule());
            _ship.AddModule(new AdditionalShieldModule { Max = 50, Value = 45 });
            _ship.AddModule(new AdditionalHPModule());

            var enemy = new Ship.Ship();
            enemy.UI = enemyUI;
            _enemies.Add(enemy);
            enemy.AddModule(CreateWeapon(enemyUI, shipUI, assets, "RocketLauncher5", 0, 4));
            enemy.AddModule(CreateWeapon(enemyUI, shipUI, assets, "Gun4", 1, 0.5f));

            //var damageModule = new WeaponService();
            //damageModule.Tick(1, _ship, new() { _ship });
            //Debug.Log("Damage");
        }

        private static Weapon CreateWeapon(GameObject shipUI, GameObject enemyUI, IAssetProvider assets, string weaponId, int indexPosition,
            float cooldown)
        {
            GameObject weaponUI = assets.Instantiate(AssetPath.WeaponsPath + weaponId);
            weaponUI.transform.parent = shipUI.transform;
            weaponUI.transform.position = shipUI.GetComponent<ShipUI>().GunPositions[indexPosition].position;
            weaponUI.GetComponent<WeaponUI>().LookAt.Target = enemyUI.transform;

            var weapon = new Weapon();
            weapon.UI = weaponUI.GetComponent<WeaponUI>();
            weapon.BulletTime = 4f;
            weapon.Cooldown.Set(cooldown);
            return weapon;
        }
    }
}