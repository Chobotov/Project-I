namespace ProjectI.Game.Player
{
    public interface IDamageble
    {
        int Health { get; }
        void SetDamage(int damage);
    }
}