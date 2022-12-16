using UnityEngine;
using UnityEngine.UI;

namespace Code.Health
{
    public class ShieldBarUI : MonoBehaviour
    {
        public Image ImageCurrent;

        public void SetValue(float current, float max)
        {
            Debug.Log($"{current}/{max}");
            ImageCurrent.fillAmount = current / max;
        }
    }
}