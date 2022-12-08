using System;
using UnityEngine;

namespace Code.PathFind
{
    public class MetroCalculator : MonoBehaviour
    {
        public void Start()
        {
            var metro = new Metro();
            metro.Initialize();
            var pair = metro.GetTwoRandomStationNames();
            metro.Calculate(pair.Item1, pair.Item2);
        }
    }
}