using System;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Module.Weapon;
using Code.Ship;
using Code.Ship.Health;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public GameObject Ship;
        public GameObject Enemy;
        public GameObject Weapon;

        private Game _game;
        private AllServices _services;

        public void Awake()
        {
            _services = AllServices.Container;
            InitServices();
            _game = new Game(_services.Signle<IShipService>());
            _game.Init(Ship, Enemy, Weapon);
            DontDestroyOnLoad(this);
        }

        public void Update()
        {
            _game.Tick(Time.deltaTime);
        }

        private void InitServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProviderProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Signle<IAssetProvider>()));
            InitGameplayServices();
        }

        private void InitGameplayServices()
        {
            _services.RegisterSingle<IHPService>(new HPService());
            _services.RegisterSingle<IShieldService>(new ShieldService());
            _services.RegisterSingle<IHealthService>(new HealthService(
                _services.Signle<IShieldService>(),
                _services.Signle<IHPService>()));
            _services.RegisterSingle<IBulletService>(new BulletService(_services.Signle<IHealthService>()));
            _services.RegisterSingle<IWeaponService>(new WeaponService(
                _services.Signle<IAssetProvider>(),
                _services.Signle<IBulletService>()));
            _services.RegisterSingle<IShipService>(new ShipService(
                _services.Signle<IHealthService>(),
                _services.Signle<IWeaponService>(),
                _services.Signle<IBulletService>()));
        }
    }
}