using System.Collections.Generic;
using System.Linq;
using Code.Module.Health;

namespace Code.Ship.Health
{
    public class HP
    {
        public float Value = 100;
        public float Max = 100;
        public List<AdditionalHPModule> AdditionalHpModules = new List<AdditionalHPModule>();
        public bool IsEmpty() => GetTotalHP() <= 0;

        public void SetAndReset(float max)
        {
            Max = max;
            Reset();
        }

        public void Reset()
        {
            Value = Max;
            AdditionalHpModules.Clear();
        }

        public float GetTotalHP()
        {
            return Value + AdditionalHpModules.Sum(it => it.Value);
        }

        public void TakeDamage(ref float damage)
        {
            if (GetAdditionalHP() > 0)
                TakeDamageToAdditionalHPModules(ref damage);
            if (damage > 0)
            {
                Value -= damage;
                if (Value < 0)
                {
                    damage = -Value;
                    Value = 0;
                }
                else damage = 0;
            }
        }

        private float GetAdditionalHP() => AdditionalHpModules.Sum(it => it.Value);

        private void TakeDamageToAdditionalHPModules(ref float damage)
        {
            foreach (var hp in AdditionalHpModules)
            {
                TakeDamageToAdditionalHPModule(hp, ref damage);
                if (damage <= 0)
                    break;
            }
        }

        private void TakeDamageToAdditionalHPModule(AdditionalHPModule hp, ref float damage)
        {
            if (hp.Value > 0)
            {
                hp.Value -= damage;
                if (hp.Value < 0)
                {
                    damage = -hp.Value;
                    hp.Value = 0;
                }
                else
                    damage = 0;
            }
        }
    }
}