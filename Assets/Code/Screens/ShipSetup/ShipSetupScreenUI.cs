using System;
using UnityEngine;

namespace Code.Screens.ShipSetup
{
    public class ShipSetupScreenUI : MonoBehaviour
    {
        public static event Action StartGame;

        public void OnStartClick()
        {
            StartGame?.Invoke();
        }
    }
}