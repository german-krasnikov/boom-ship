using UnityEngine;

namespace Code.Bullet
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