using Code.Infrastructure;

namespace Code.Ship.Health
{
    public interface IShieldService : IService
    {
        void Tick(float tick, Ship ship);
        void TakeDamage(ref float damage, Ship ship);
    }
}