using System.Collections.Generic;
using System.Linq;
using Code.Module.Health;
using Code.Module.Weapon;

namespace Code.Ship
{
    public class Ship
    {
        public Health.Health Health = new Health.Health();
        private List<Module.BaseModule> Modules = new List<Module.BaseModule>();

        public void AddModule(Module.BaseModule module)
        {
            Modules.Add(module);

            if (module.GetType() == typeof(AdditionalShieldModule))
                Health.Shield.AdditionalShields.Add(module as AdditionalShieldModule);
            else if (module.GetType() == typeof(AdditionalHPModule))
                Health.HP.AdditionalHpModules.Add(module as AdditionalHPModule);
        }

        public IEnumerable<Weapon> Weapons() => Modules.OfType<Weapon>();
        public IEnumerable<SpeedupRestoreShieldModule> SpeedupRestoreShields() => Modules.OfType<SpeedupRestoreShieldModule>();
        public IEnumerable<SpeedupReloadWeaponModule> SpeedupReloadWeapons() => Modules.OfType<SpeedupReloadWeaponModule>();
    }
}