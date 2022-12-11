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
        private GameObject _gameResultScreen;

        public GameResultState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterDependencies();
            CreateAndInitGameResultScreen();
        }

        public void Exit()
        {
            Object.Destroy(_gameResultScreen);
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
        }

        private void CreateAndInitGameResultScreen()
        {
            _gameResultScreen = _factory.CreateGameResultScreen();
            _gameResultScreen.GetComponent<GameResultScreenUI>().Set(_world.Ship.Health.IsAlive());
        }
    }
}