using System.Collections.Generic;
using Code.Module.Weapon;
using Code.Ship.Health;

namespace Code.Ship
{
    public class ShipService : IShipService
    {
        private IHealthService _healthService;
        private IWeaponService _weaponService;
        private IBulletService _bulletService;

        public ShipService(IHealthService healthService, IWeaponService weaponService, IBulletService bulletService)
        {
            _healthService = healthService;
            _weaponService = weaponService;
            _bulletService = bulletService;
        }

        public void Tick(float tick, Ship ship, List<Ship> enemies)
        {
            _healthService.Tick(tick, ship);
            _weaponService.Tick(tick, ship, enemies);
            _bulletService.Tick(tick);
        }
    }
}