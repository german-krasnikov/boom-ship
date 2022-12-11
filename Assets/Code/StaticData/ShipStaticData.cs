using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "ShipData", menuName = "Static Data/Ship")]
    public class ShipStaticData : ScriptableObject
    {
        public string Name;
        public GameObject Prefab;
        public float HP = 100;
        public float Shield = 100;
        public float ShieldIncCooldown = 1;
        public float ShieldIncValue = 1;
        public int WeaponCount = 2;
        public int ModuleCount = 2;
    }
}