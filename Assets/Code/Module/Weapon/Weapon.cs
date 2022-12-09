using Code.Data;

namespace Code.Module.Weapon
{
    public class Weapon : BaseModule
    {
        public float Damage = 30;
        public Cooldown Cooldown = new Cooldown(1);

        public bool CanShot() => Cooldown.IsExpired();
    }
}