using Code.Logic;
using UnityEngine;

namespace Code.Weapon
{
    public class WeaponUI : MonoBehaviour
    {
        public GameObject BulletSpawnPoint;
        public LookAt LookAt;

        public void SetLookAtTarget(GameObject target)
        {
            LookAt.Target = target.transform;
        }
    }
}