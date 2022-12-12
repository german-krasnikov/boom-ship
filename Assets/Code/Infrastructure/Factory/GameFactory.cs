using Code.Infrastructure.AssetManagement;
using Code.Screens.ShipSetup;
using Code.StaticData;
using Code.Weapon;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateBullet(GameObject at) =>
            _assetProvider.Instantiate(AssetPath.BulletPath, at: at.transform.position);

        public void CreateHud() =>
            _assetProvider.Instantiate(AssetPath.HudPath);

        public ShipSetupScreenUI CreateShipSetupScreen() =>
            _assetProvider.Instantiate(AssetPath.ShipSetupScreenPath).GetComponent<ShipSetupScreenUI>();

        public Weapon.Weapon CreateWeapon(Ship.Ship ship, WeaponStaticData weaponData, int indexPosition)
        {
            var weapon = new Weapon.Weapon();
            weapon.BulletTime = weaponData.BulletTime;
            weapon.Cooldown.Set(weaponData.Cooldown);
            weapon.Damage = weaponData.Damage;
            ship.AddModule(weapon);
            
            WeaponUI weaponUI = _assetProvider.Instantiate(weaponData.Prefab).GetComponent<WeaponUI>();
            weaponUI.transform.parent = ship.UI.transform;
            weaponUI.transform.position = ship.UI.GunPositions[indexPosition].position;

            weapon.UI = weaponUI;
            return weapon;
        }

        public GameObject CreateGameResultScreen() => _assetProvider.Instantiate(AssetPath.GameResultScreenPath);

        public Ship.Ship CreateShip(ShipStaticData shipData, Vector3 at)
        {
            var ship = new Ship.Ship();
            ship.UI = _assetProvider.Instantiate(shipData.Prefab, at).GetComponent<ShipUI>();
            ship.Health.HP.SetAndReset(shipData.HP);
            ship.Health.Shield.SetAndReset(shipData.Shield, shipData.ShieldIncValue, shipData.ShieldIncCooldown);
            return ship;
        }
    }
}