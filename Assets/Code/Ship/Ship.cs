using System.Collections.Generic;
using System.Linq;
using Code.Module;
using Code.Module.Health;
using UnityEngine;

namespace Code.Ship
{
    public class Ship
    {
        public ShipUI UI;

        public Health.Health Health = new Health.Health();
        private List<BaseModule> Modules = new List<BaseModule>();

        public IEnumerable<Weapon.Weapon> Weapons() => Modules.OfType<Weapon.Weapon>();
        public IEnumerable<SpeedupRestoreShieldModule> SpeedupRestoreShields() => Modules.OfType<SpeedupRestoreShieldModule>();
        public IEnumerable<SpeedupReloadWeaponModule> SpeedupReloadWeapons() => Modules.OfType<SpeedupReloadWeaponModule>();

        public void AddModule(BaseModule module)
        {
            Modules.Add(module);

            if (module.GetType() == typeof(AdditionalShieldModule))
                Health.Shield.AdditionalShields.Add(module as AdditionalShieldModule);
            else if (module.GetType() == typeof(AdditionalHPModule))
                Health.HP.AdditionalHpModules.Add(module as AdditionalHPModule);
        }

        public void SetTargetForWeapons(GameObject target)
        {
            foreach (var weapon in Weapons())
                weapon.UI.SetLookAtTarget(target);
        }
    }
}