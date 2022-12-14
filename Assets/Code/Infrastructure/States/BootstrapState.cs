using Code.Bullet;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Ship;
using Code.Ship.Health;
using Code.Weapon;
using Code.World;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterServices();
            _stateMachine.Enter<ShipSetupState>();
        }

        public void Tick(float deltaTime)
        {
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProviderProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            RegisterGameplayServices();
        }

        private void RegisterGameplayServices()
        {
            _services.RegisterSingle<GameStateMachine>(_stateMachine);
            _services.RegisterSingle<IWorldService>(new WorldService());
            _services.RegisterSingle<IHPService>(new HPService());
            _services.RegisterSingle<IShieldService>(new ShieldService());
            _services.RegisterSingle<IHealthService>(new HealthService(
                _services.Single<IShieldService>(),
                _services.Single<IHPService>()));
            _services.RegisterSingle<IBulletService>(new BulletService(
                _services.Single<IHealthService>(),
                _services.Single<IWorldService>(),
                _services.Single<IAssetProvider>()
            ));
            _services.RegisterSingle<IWeaponService>(new WeaponService(
                _services.Single<IAssetProvider>(),
                _services.Single<IBulletService>()));
            _services.RegisterSingle<IShipService>(new ShipService(
                _services.Single<IHealthService>(),
                _services.Single<IWeaponService>(),
                _services.Single<IBulletService>()));
        }
    }
}