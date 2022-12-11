using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Module.Health;
using Code.Ship;
using Code.Weapon;
using Code.World;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        private IShipService _shipService;
        private IGameFactory _factory;
        private World.World _world;

        public GameLoopState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        private void RegisterDependencies()
        {
            if (_shipService != null)
                return;
            _shipService = _services.Single<IShipService>();
            _world = _services.Single<IWorldService>().World;
            _factory = _services.Single<IGameFactory>();
        }

        public void Enter()
        {
            RegisterDependencies();
            Init();
        }

        public void Tick(float deltaTime)
        {
            _shipService.Tick(deltaTime, _world.Ship, _world.Enemies);
            _shipService.Tick(deltaTime, _world.Enemies.First(), new() { _world.Ship });
            //var enemy = _enemies.First();
            //Debug.Log(enemy.Health.HP.GetTotalHP() + " " + enemy.Health.Shield.GetTotalShield());
            //Debug.Log(_ship.Health.HP.GetTotalHP() + " " + _ship.Health.Shield.Value + " " + _ship.Health.Shield.AdditionalShields.First().Value);
        }

        public void Exit()
        {
        }

        public void Init()
        {
            var assets = _services.Single<IAssetProvider>();
            var shipUI = assets.Instantiate(AssetPath.ShipPath);
            var enemyUI = assets.Instantiate(AssetPath.ShipPath, new Vector3(10, 0, 10));

            _world.Ship = new Ship.Ship();
            var ship = _world.Ship;
            ship.UI = shipUI;
            ship.Health.Shield.Value = 90;
            //_ship.Health.Shield.IncCooldown.BaseCooldown = 2;
            ship.AddModule(_factory.CreateWeapon(shipUI, enemyUI, "RocketLauncher5", 0, 4));
            ship.AddModule(_factory.CreateWeapon(shipUI, enemyUI, "Gun4", 1, 0.5f));
            ship.AddModule(new SpeedupRestoreShieldModule());
            ship.AddModule(new AdditionalShieldModule { Max = 50, Value = 45 });
            ship.AddModule(new AdditionalHPModule());

            var enemy = new Ship.Ship();
            enemy.UI = enemyUI;
            _world.Enemies.Add(enemy);
            enemy.AddModule(_factory.CreateWeapon(enemyUI, shipUI, "RocketLauncher5", 0, 4));
            enemy.AddModule(_factory.CreateWeapon(enemyUI, shipUI, "Gun4", 1, 0.5f));

            //var damageModule = new WeaponService();
            //damageModule.Tick(1, _ship, new() { _ship });
            //Debug.Log("Damage");
        }
    }
}