using System.Linq;
using Code.Ship;
using Code.World;

namespace Code.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        private IShipService _shipService;
        private World.World _world;

        public GameLoopState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterDependencies();
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

        private void RegisterDependencies()
        {
            if (_shipService != null)
                return;
            _shipService = _services.Single<IShipService>();
            _world = _services.Single<IWorldService>().World;
        }
    }
}