using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Module;
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
            for (int i = 0; i < shipData.ModuleCount; i++)
                CreateModule(ship, moduleDataList[i]);
            return ship;
        }

        private void CreateModule(Ship.Ship ship, ModuleStaticData moduleData)
        {
            switch (moduleData.Type)
            {
                case ModuleType.SpeedupReloadWeapon:
                    ship.AddModule(new SpeedupReloadWeaponModule
                    {
                        SpeedupPercent = moduleData.Value
                    });
                    break;
                case ModuleType.AdditionalHP:
                    ship.AddModule(new AdditionalHPModule
                    {
                        Value = moduleData.Value
                    });
                    break;
                case ModuleType.AdditionalShield:
                    ship.AddModule(new AdditionalShieldModule
                    {
                        Value = moduleData.Value
                    });
                    break;
                case ModuleType.SpeedupRestoreShield:
                    ship.AddModule(new SpeedupRestoreShieldModule
                    {
                        SpeedupPercent = moduleData.Value
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}