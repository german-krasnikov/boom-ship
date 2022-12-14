using Code.Logic;
using UnityEngine;

namespace Code.Bullet
{
    public class Bullet
    {
        public BulletUI UI;
        public Ship.Ship Target;
        public float Damage;
        public Cooldown Cooldown = new Cooldown(1);

        public bool Done() => Cooldown.IsExpired();
    }
}