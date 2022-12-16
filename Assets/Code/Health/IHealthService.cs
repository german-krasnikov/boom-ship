using Code.Infrastructure;

namespace Code.Health
{
    public interface IHealthService : IService
    {
        void Tick(float tick, Ship.Ship ship);
        void TakeDamage(float damage, Ship.Ship ship);
    }
}