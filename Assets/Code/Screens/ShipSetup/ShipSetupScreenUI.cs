using System;
using Code.StaticData;
using UnityEngine;

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
            StartGame?.Invoke();
        }
    }
}