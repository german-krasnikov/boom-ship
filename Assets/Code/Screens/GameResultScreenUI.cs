using System;
using TMPro;
using UnityEngine;

namespace Code.Screens
{
    public class GameResultScreenUI : MonoBehaviour
    {
        public static event Action RestartGame;
   
        public TMP_Text Result;

        public void Set(bool isAlive)
        {
            Result.text = isAlive ? "You win!" : "You lose";
        }

        public void OnRestartClick()
        {
            RestartGame?.Invoke();
        }
    }
}