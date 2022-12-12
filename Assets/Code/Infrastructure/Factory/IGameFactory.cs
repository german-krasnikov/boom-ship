using Code.Screens;
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
        GameResultScreenUI CreateGameResultScreen();
        Weapon.Weapon CreateWeapon(Ship.Ship ship, WeaponStaticData weaponData, int indexPosition);

        Ship.Ship CreateShip(ShipStaticData getSelectedShip, Vector3 at);
    }
}