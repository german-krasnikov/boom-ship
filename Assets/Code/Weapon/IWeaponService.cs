using System.Collections.Generic;
using Code.Infrastructure;

namespace Code.Weapon
{
    public interface IWeaponService : IService
    {
        void Tick(float tick, Ship.Ship ship, List<Ship.Ship> enemies);
    }
}