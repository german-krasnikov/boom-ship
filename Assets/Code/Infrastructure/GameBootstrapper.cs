using System;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        public GameObject Ship;
        public GameObject Enemy;
        public GameObject Weapon;
        private Game _game;

        public void Awake()
        {
            _game = new Game();
            _game.Init(Ship, Enemy, Weapon);
            DontDestroyOnLoad(this);
        }

        public void Update()
        {
            _game.Tick(Time.deltaTime);
        }
    }
}