using UnityEngine;

namespace ProjectI.Game.Player
{
    public class RigidbodyMoveBehaviour : IMoveble
    {
        private readonly Rigidbody rigidbody;

        public RigidbodyMoveBehaviour(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
        }

        public void Move(float moveInput, float speed)
        {
            rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);
        }

        public void Jump(float jumpForce)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}