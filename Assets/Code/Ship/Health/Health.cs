namespace Code.Ship.Health
{
    public class Health
    {
        public HP HP = new HP();
        public Shield Shield = new Shield();

        public bool IsAlive() => !Shield.IsEmpty() || !HP.IsEmpty();

        public float GetTotal()
        {
            return HP.GetTotalHP() + Shield.GetTotalShield();
        }
    }
}