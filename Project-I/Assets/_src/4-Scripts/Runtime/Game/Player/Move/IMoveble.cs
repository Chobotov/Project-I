namespace ProjectI.Game.Player
{
    public interface IMoveble
    {
        void Move(float moveInput, float speed);
        void Jump(float jumpForce);
    }
}