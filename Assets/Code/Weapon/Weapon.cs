using Code.Logic;
using Code.Module;

namespace Code.Weapon
{
    public class Weapon : BaseModule
    {
        public WeaponUI UI;
        
        public float Damage = 30;
        public Cooldown Cooldown = new Cooldown(1);
        public float BulletTime = 1f;

        public bool CanShot() => Cooldown.IsExpired();
    }
}