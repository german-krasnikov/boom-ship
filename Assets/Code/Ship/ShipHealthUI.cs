using System;
using UnityEngine;

namespace Code.Ship
{
    public class ShipHealthUI : MonoBehaviour
    {
        public float Current;
        public float Max;

        public event Action HealthChanged;

        public void TakeDamage(float value)
        {
            Current -= value;

            HealthChanged?.Invoke();
        }
    }
}