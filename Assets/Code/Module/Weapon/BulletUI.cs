using System.Collections;
using UnityEngine;

namespace Code.Module.Weapon
{
    public class BulletUI : MonoBehaviour
    {
        public Bullet Bullet;

        public void Initialize(Bullet bullet)
        {
            Bullet = bullet;
        }

        public void Tick(float tick)
        {
            if (Bullet == null)
                return;
        }
    }
}