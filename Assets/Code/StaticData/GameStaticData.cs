using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Static Data/Game")]
    public class GameStaticData : ScriptableObject
    {
        public ShipStaticData[] Ships;
        public WeaponStaticData[] Weapons;
        public ModuleStaticData[] Modules;
    }
}