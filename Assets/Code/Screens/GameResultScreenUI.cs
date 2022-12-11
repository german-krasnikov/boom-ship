using TMPro;
using UnityEngine;

namespace Code.Screens
{
    public class GameResultScreenUI : MonoBehaviour
    {
        public TMP_Text Result;

        public void Set(bool isAlive)
        {
            Result.text = isAlive ? "You win!" : "You lose";
        }
    }
}