using System;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.States;
using Code.Module.Weapon;
using Code.Ship;
using Code.Ship.Health;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField]
        private GameStateMachine _stateMachine;
        private Game _game;
        private AllServices _services;

        public void Awake()
        {
            _services = AllServices.Container;
            _stateMachine.Construct(_services);
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}