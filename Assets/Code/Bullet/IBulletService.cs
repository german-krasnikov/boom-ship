using Code.Infrastructure;

namespace Code.Bullet
{
    public interface IBulletService : IService
    {
        void Tick(float tick);
        void AddBullet(Ship.Ship bullet, Weapon.Weapon weapon);
    }
}