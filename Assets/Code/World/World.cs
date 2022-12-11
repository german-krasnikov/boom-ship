using System.Collections.Generic;

namespace Code.World
{
    public class World
    {
        public Ship.Ship Ship;
        public List<Ship.Ship> Enemies = new List<Ship.Ship>();
        public List<Bullet.Bullet> Bullets = new List<Bullet.Bullet>();
    }
}