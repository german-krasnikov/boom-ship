using System;
using Code.Logic;
using Code.Logic.Carousel;
using Code.Screens.ShipSetup.Carousel;
using Code.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Screens.ShipSetup
{
    public class ShipSetupScreenUI : MonoBehaviour
    {
        public static event Action StartGame;

        public GameStaticData GameData;
        [SerializeField]
        private ShipSetupPanelUI _playerShipPanel;

        public void Awake()
        {
            _playerShipPanel.Init(GameData);
        }

        public void OnStartClick()
        {
            StartGame?.Invoke();
        }
    }
}