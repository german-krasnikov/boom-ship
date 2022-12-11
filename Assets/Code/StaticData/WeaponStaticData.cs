using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Static Data/Weapon")]
    public class WeaponStaticData : ScriptableObject
    {
        public string Name;
        public GameObject Prefab;
        public float Damage = 30;
        public float Cooldown = 1f;
        public float BulletTime = 1f;
    }
}