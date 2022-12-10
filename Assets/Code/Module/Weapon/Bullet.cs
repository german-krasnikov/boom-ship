using Code.Data;

namespace Code.Module.Weapon
{
    public class Bullet
    {
        public Ship.Ship Target;
        public float Damage;
        public Cooldown Cooldown = new Cooldown(1);

        public bool Done() => Cooldown.IsExpired();
        
    }
}