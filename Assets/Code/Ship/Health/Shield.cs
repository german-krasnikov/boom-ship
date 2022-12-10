using System.Collections.Generic;
using System.Linq;
using Code.Logic;
using Code.Module.Health;

namespace Code.Ship.Health
{
    public class Shield
    {
        public float Value = 100;
        public float IncValue = 1f;
        public float Max = 100;
        public Cooldown IncCooldown = new Cooldown(1);
        public List<AdditionalShieldModule> AdditionalShields = new List<AdditionalShieldModule>();
        public bool IsEmpty() => GetTotalShield() <= 0;

        public void Reset()
        {
            Value = Max;
            IncCooldown.Reset();
            AdditionalShields.Clear();
        }

        public float GetTotalShield()
        {
            return Value + GetAdditionalShields();
        }

        public void Inc()
        {
            if (Value < Max)
            {
                Value += IncValue;
                if (Value >= Max)
                    IncAdditionalShields(Value - Max);
            }
            else if (GetTotalShield() < Max + GetMaxAdditionalShields())
                IncAdditionalShields(IncValue);
            IncCooldown.Reset();
        }

        public void TakeDamage(ref float damage)
        {
            if (GetAdditionalShields() > 0)
                TakeDamageToAdditionalShields(ref damage);
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

        private float GetMaxAdditionalShields() => AdditionalShields.Sum(it => it.Max);
        private float GetAdditionalShields() => AdditionalShields.Sum(it => it.Value);

        private void IncAdditionalShields(float inc)
        {
            foreach (var shield in AdditionalShields)
            {
                IncAdditionalShield(shield, ref inc);
                if (inc <= 0)
                    break;
            }
        }

        private void IncAdditionalShield(AdditionalShieldModule shield, ref float inc)
        {
            if (shield.Value < shield.Max)
                shield.Value += inc;
            if (shield.Value > shield.Max)
                inc = shield.Value - shield.Max;
            else
                inc = 0;
        }

        private void TakeDamageToAdditionalShields(ref float damage)
        {
            foreach (var shield in AdditionalShields)
            {
                TakeDamageToAdditionalShield(shield, ref damage);
                if (damage <= 0)
                    break;
            }
        }

        private void TakeDamageToAdditionalShield(AdditionalShieldModule shield, ref float damage)
        {
            if (shield.Value > 0)
            {
                shield.Value -= damage;
                if (shield.Value < 0)
                {
                    damage = -shield.Value;
                    shield.Value = 0;
                }
                else
                    damage = 0;
            }
        }
    }
}