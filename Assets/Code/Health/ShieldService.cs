using System.Linq;

namespace Code.Health
{
    public class ShieldService : IShieldService
    {
        public void Tick(float tick, Ship.Ship ship)
        {
            var shield = ship.Health.Shield;
            shield.IncCooldown.TickWithSpeedUp(tick, ship.SpeedupRestoreShields().Sum(it => it.SpeedupPercent));
            if (shield.IncCooldown.IsExpired())
                shield.Inc();
        }

        public void TakeDamage(ref float damage, Ship.Ship ship)
        {
            ship.Health.Shield.TakeDamage(ref damage);
        }
    }
}