﻿using Code.Infrastructure.AssetManagement;
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

        public GameObject CreateGameResultScreen() => _assetProvider.Instantiate(AssetPath.GameResultScreenPath);

        public Weapon.Weapon CreateWeapon(GameObject shipUI, GameObject enemyUI, string weaponId, int indexPosition, float cooldown)
        {
            GameObject weaponUI = _assetProvider.Instantiate(AssetPath.WeaponsPath + weaponId);
            weaponUI.transform.parent = shipUI.transform;
            weaponUI.transform.position = shipUI.GetComponent<ShipUI>().GunPositions[indexPosition].position;
            weaponUI.GetComponent<WeaponUI>().LookAt.Target = enemyUI.transform;

            var weapon = new Weapon.Weapon();
            weapon.UI = weaponUI.GetComponent<WeaponUI>();
            weapon.BulletTime = 4f;
            weapon.Cooldown.Set(cooldown);
            weapon.Damage = 20;
            return weapon;
        }

        public Ship.Ship CreateShip(ShipStaticData shipData, Vector3 at)
        {
            var ship = new Ship.Ship();
            ship.UI = _assetProvider.Instantiate(shipData.Prefab, at);
            ship.Health.HP.SetAndReset(shipData.HP);
            ship.Health.Shield.SetAndReset(shipData.Shield, shipData.ShieldIncValue, shipData.ShieldIncCooldown);
            return ship;
        }
    }
}