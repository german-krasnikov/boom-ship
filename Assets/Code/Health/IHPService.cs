using Code.Infrastructure;

namespace Code.Health
{
    public interface IHPService : IService
    {
        void TakeDamage(ref float damage, Ship.Ship ship);
    }
}