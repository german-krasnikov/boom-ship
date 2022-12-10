using System.Linq;

namespace Code.Ship.Health
{
    public class HealthService : IHealthService
    {
        private readonly IShieldService _shieldService;
        private readonly IHPService _hpService;

        public HealthService(IShieldService shieldService, IHPService hpService)
        {
            _shieldService = shieldService;
            _hpService = hpService;
        }

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