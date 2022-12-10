using Code.Infrastructure;
using Code.Ship.Health;

namespace Code.Module.Weapon
{
    public interface IBulletService : IService
    {
        void Tick(float tick);
        void AddBullet(Bullet bullet);
    }
}