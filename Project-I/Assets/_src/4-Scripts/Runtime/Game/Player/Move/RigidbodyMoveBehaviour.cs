using System;
using UnityEngine;

namespace ProjectI.Game.Player
{
    public class RigidbodyMoveBehaviour : IMoveble
    {
        private readonly Rigidbody rigidbody;

        private float prevScale = 1;

        public RigidbodyMoveBehaviour(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
        }

        public void Move(float moveInput, float speed)
        {
            rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

            var rotate = moveInput > 0
                ? 1f
                : -1f;

            if (moveInput == 0) rotate = prevScale;

            rigidbody.transform.localScale = new Vector3(rotate, 1f, 1f);

            prevScale = rotate;
        }

        public void Jump(float jumpForce, Action? onFinish = null)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void Move(float speed)
        {
        }
    }
}