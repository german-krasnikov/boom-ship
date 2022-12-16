namespace Code.Health
{
    public class HPService : IHPService
    {
        public void TakeDamage(ref float damage, Ship.Ship ship)
        {
            ship.Health.HP.TakeDamage(ref damage);
        }
    }
}