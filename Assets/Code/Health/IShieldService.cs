using Code.Infrastructure;

namespace Code.Health
{
    public interface IShieldService : IService
    {
        void Tick(float tick, Ship.Ship ship);
        void TakeDamage(ref float damage, Ship.Ship ship);
    }
}