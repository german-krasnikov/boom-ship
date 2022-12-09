namespace Code.Ship.Health
{
    public class HPService
    {
        public void TakeDamage(ref float damage, Ship ship)
        {
            ship.Health.HP.TakeDamage(ref damage);
        }
    }
}