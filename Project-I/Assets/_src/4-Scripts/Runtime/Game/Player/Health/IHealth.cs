namespace ProjectI.Game.Player
{
    public interface IHealth
    {
        int Health { get; }
        void TakeDamage(int damage);
        void Die();
    }
}