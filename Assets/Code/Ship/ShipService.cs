using System.Collections.Generic;
using Code.Module.Weapon;
using Code.Ship.Health;

namespace Code.Ship
{
    public class ShipService
    {
        private HealthService _healthService = new HealthService();
        private WeaponService _weaponService = new WeaponService();
        private BulletService _bulletService = new BulletService();

        public void Tick(float tick, Ship ship, List<Ship> enemies)
        {
            _healthService.Tick(tick, ship);
            _weaponService.Tick(tick, ship, enemies, _bulletService);
            _bulletService.Tick(tick, _healthService);
        }
    }
}