namespace ProjectI.Game.Player
{
    public class PlayerHealth : IHealth
    {
        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {
            Health = Health -= damage;

            if (Health <= 0)
            {
                Health = 0;

                Die();
            }
        }

        public void Die()
        {
            
        }
    }
}