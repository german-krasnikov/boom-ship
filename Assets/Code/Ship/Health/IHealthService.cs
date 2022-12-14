using Code.Infrastructure;

namespace Code.Ship.Health
{
    public interface IHealthService : IService
    {
        void Tick(float tick, Ship ship);
        void TakeDamage(float damage, Ship ship);
    }
}