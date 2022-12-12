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
        public ShipSetupPanelUI PlayerShipPanel;
        public ShipSetupPanelUI EnemyShipPanel;

        public void Awake()
        {
            PlayerShipPanel.Init(GameData);
            EnemyShipPanel.Init(GameData);
        }

        public void OnStartClick()
        {
            //_playerShipPanel.GetSelectedShip().Name

            StartGame?.Invoke();
        }
    }
}