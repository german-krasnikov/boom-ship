namespace Code.Data
{
    public class Cooldown
    {
        public float BaseCooldown = 1;
        public float Current = 1;

        public Cooldown(float baseCooldown)
        {
            BaseCooldown = baseCooldown;
        }

        public void Set(float value)
        {
            BaseCooldown = value;
            Current = value;
        }

        public void Reset()
        {
            Current = BaseCooldown;
        }

        public bool IsExpired()
        {
            return Current <= 0;
        }

        public void Tick(float time)
        {
            Current -= time;
        }

        public void TickWithSpeedUp(float time, float speedUpPercent)
        {
            Current -= time * (1 + speedUpPercent / 100);
        }
    }
}