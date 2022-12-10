using Code.Infrastructure;

namespace Code.Ship.Health
{
    public interface IHPService : IService
    {
        void TakeDamage(ref float damage, Ship ship);
    }
}