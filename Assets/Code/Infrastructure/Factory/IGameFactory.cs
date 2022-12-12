using Code.Screens.ShipSetup;
using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateBullet(GameObject at);
        void CreateHud();
        ShipSetupScreenUI CreateShipSetupScreen();
        GameObject CreateGameResultScreen();
        public Weapon.Weapon CreateWeapon(GameObject shipUI, GameObject enemyUI, string weaponId, int indexPosition, float cooldown);

        Ship.Ship CreateShip(ShipStaticData getSelectedShip, Vector3 at);
    }
}