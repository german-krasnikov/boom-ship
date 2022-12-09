using System;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        public void Awake()
        {
            _game = new Game();
            _game.Init();
            DontDestroyOnLoad(this);
        }

        public void Update()
        {
            _game.Tick(Time.deltaTime);
        }
    }
}