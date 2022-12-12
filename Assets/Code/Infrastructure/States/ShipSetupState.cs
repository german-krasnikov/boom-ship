using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Logic;
using Code.Module.Health;
using Code.Screens.ShipSetup;
using Code.StaticData;
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
        private ShipSetupScreenUI _shipSetupScreen;
        private IAssetProvider _assets;

        public ShipSetupState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterDependencies();
            _shipSetupScreen = _factory.CreateShipSetupScreen();
            ShipSetupScreenUI.StartGame += StartGame;
        }

        public void Exit()
        {
            ShipSetupScreenUI.StartGame -= StartGame;
            _assets.Destroy(_shipSetupScreen.gameObject);
            CreateShips();
        }

        public void Tick(float deltaTime)
        {
        }

        private void RegisterDependencies()
        {
            if (_world != null)
                return;
            _world = _services.Single<IWorldService>().World;
            _factory = _services.Single<IGameFactory>();
            _assets = _services.Single<IAssetProvider>();
        }

        private void StartGame()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private void CreateShips()
        {
            _world.Ship = CreateShipFromShipSetupPanel(_shipSetupScreen.PlayerShipPanel, new Vector3());
            _world.Enemies.Add(CreateShipFromShipSetupPanel(_shipSetupScreen.EnemyShipPanel, new Vector3(10, 0, 10)));

            _world.Ship.SetTargetForWeapons(_world.Enemies.First().UI.gameObject);
            _world.Enemies.First().SetTargetForWeapons(_world.Ship.UI.gameObject);
        }

        private Ship.Ship CreateShipFromShipSetupPanel(ShipSetupPanelUI shipSetupPanel, Vector3 position)
        {
            var ship = CreateShip(
                shipSetupPanel.GetSelectedShip(),
                shipSetupPanel.GetSelectedWeapons().ToList(),
                shipSetupPanel.GetSelectedModules().ToList(),
                position);
            return ship;
        }

        private Ship.Ship CreateShip(ShipStaticData shipData, List<WeaponStaticData> weaponDataList, List<ModuleStaticData> moduleDataList,
            Vector3 position)
        {
            var ship = _factory.CreateShip(shipData, position);
            for (int i = 0; i < shipData.WeaponCount; i++)
                _factory.CreateWeapon(ship, weaponDataList[i], i);
            return ship;
        }

        /*private void CreateShips()
        {
            var assets = _services.Single<IAssetProvider>();
            var shipUI = assets.Instantiate(AssetPath.ShipPath);
            var enemyUI = assets.Instantiate(AssetPath.ShipPath, new Vector3(10, 0, 10));

            _world.Ship = new Ship.Ship();
            var ship = _world.Ship;
            ship.UI = shipUI.GetComponent<ShipUI>();
            ship.Health.Shield.Value = 90;

            ship.AddModule(_factory.CreateWeapon(ship.UI, "RocketLauncher5", 0, 4));
            ship.AddModule(_factory.CreateWeapon(ship.UI, "Shocker5", 1, 0.5f));
            ship.AddModule(new SpeedupRestoreShieldModule());
            ship.AddModule(new AdditionalShieldModule { Max = 50, Value = 45 });
            ship.AddModule(new AdditionalHPModule());

            var enemy = new Ship.Ship();
            enemy.UI = enemyUI.GetComponent<ShipUI>();
            _world.Enemies.Add(enemy);
            enemy.AddModule(_factory.CreateWeapon(enemy.UI, "RocketLauncher5", 0, 4));
            enemy.AddModule(_factory.CreateWeapon(enemy.UI, "Gun4", 1, 0.5f));
        }*/
    }
}