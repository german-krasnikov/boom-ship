using System.Linq;

namespace Code.Ship.Health
{
    public class HealthService
    {
        private ShieldService _shieldService = new ShieldService();
        private HPService _hpService = new HPService();

        public void Tick(float tick, Ship ship)
        {
            _shieldService.Tick(tick, ship);
        }

        public void TakeDamage(float damage, Ship ship)
        {
            if (!ship.Health.Shield.IsEmpty())
                _shieldService.TakeDamage(ref damage, ship);
            if (damage > 0)
                _hpService.TakeDamage(ref damage, ship);
        }
    }
}