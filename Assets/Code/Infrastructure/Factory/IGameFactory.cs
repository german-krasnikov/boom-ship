using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateBullet(GameObject at);
        void CreateHud();
        public Weapon.Weapon CreateWeapon(GameObject shipUI, GameObject enemyUI, string weaponId, int indexPosition, float cooldown);
    }
}