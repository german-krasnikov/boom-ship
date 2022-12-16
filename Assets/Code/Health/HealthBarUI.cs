using TMPro;
using UnityEngine;

namespace Code.Health
{
    public class HealthBarUI : MonoBehaviour
    {
        public TMP_Text _value;

        public void SetValue(float currentHP, float currentShield)
        {
            _value.text = $"<color=red>{currentHP} <color=white>| {currentShield}";
        }
    }
}