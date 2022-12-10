using System;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public GameObject Ship;
        public GameObject Enemy;
        public GameObject Weapon;
        
        private Game _game;
        private  AllServices _services;

        public void Awake()
        {
            _services = AllServices.Container;
            InitServices();
            _game = new Game();
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
        }
    }
}