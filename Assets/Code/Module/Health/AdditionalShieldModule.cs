namespace Code.Module.Health
{
    public class AdditionalShieldModule : BaseModule
    {
        public float Value = 50;
        public float Max = 50;

        public void Reset()
        {
            Value = Max;
        }
    }
}