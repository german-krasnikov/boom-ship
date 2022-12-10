namespace Code.Ship.Health
{
    public interface IHPService
    {
        void TakeDamage(ref float damage, Ship ship);
    }
}