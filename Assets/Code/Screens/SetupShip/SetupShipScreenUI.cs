using System;
using UnityEngine;

namespace Code.Screens.SetupShip
{
    public class SetupShipScreenUI : MonoBehaviour
    {
        public static event Action StartGame;

        public void OnStartClick()
        {
            StartGame?.Invoke();
        }
    }
}