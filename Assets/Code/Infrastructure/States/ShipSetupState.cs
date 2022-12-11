using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Module.Health;
using Code.Screens.ShipSetup;
using Code.Ship;
using Code.World;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class ShipSetupState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        private IGameFactory _factory;
        private World.World _world;

        public ShipSetupState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterDependencies();
            ShipSetupScreenUI.StartGame += StartGame;
            Init();
        }

        public void Exit()
        {
            ShipSetupScreenUI.StartGame -= StartGame;
        }

        public void Tick(float deltaTime)
        {
        }

        private void StartGame()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private void RegisterDependencies()
        {
            if (_world != null)
                return;
            _world = _services.Single<IWorldService>().World;
            _factory = _services.Single<IGameFactory>();
        }

        private void Init()
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