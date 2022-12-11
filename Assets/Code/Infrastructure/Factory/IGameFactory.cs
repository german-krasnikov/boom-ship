using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateBullet(GameObject at);
        void CreateHud();
        GameObject CreateShipSetupScreen();
        GameObject CreateGameResultScreen();
        public Weapon.Weapon CreateWeapon(GameObject shipUI, GameObject enemyUI, string weaponId, int indexPosition, float cooldown);
    }
}