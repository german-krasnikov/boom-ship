using Code.Infrastructure.Factory;
using Code.Screens;
using Code.World;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class GameResultState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        private IGameFactory _factory;
        private World.World _world;
        private GameResultScreenUI _gameResultScreen;
        private IWorldService _worldService;

        public GameResultState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterDependencies();
            CreateAndInitGameResultScreen();
            GameResultScreenUI.RestartGame += RestartGame;
        }

        public void Exit()
        {
            GameResultScreenUI.RestartGame -= RestartGame;
            Object.Destroy(_gameResultScreen.gameObject);
            _worldService.Clear();
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
            _worldService = _services.Single<IWorldService>();
        }

        private void CreateAndInitGameResultScreen()
        {
            _gameResultScreen = _factory.CreateGameResultScreen();
            _gameResultScreen.Set(_world.Ship.Health.IsAlive());
        }

        private void RestartGame()
        {
            _stateMachine.Enter<ShipSetupState>();
        }
    }
}