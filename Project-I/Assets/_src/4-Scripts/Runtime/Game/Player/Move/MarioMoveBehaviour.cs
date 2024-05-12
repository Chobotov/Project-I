using UnityEngine;

namespace ProjectI.Game.Player
{
    public class MarioMoveBehaviour : IMoveble
    {
        private float gravity;
        
        private bool isJumpPressed = false;
        private float initialJumpVelocity;
        private float maxJumpHeight = 1.0f;
        private float maxJumpTime = .5f;
        private bool isJumping = false;

        public MarioMoveBehaviour()
        {
            SetupJumpParameters();
        }
        
        public void Move(float moveInput, float speed)
        {
            
        }

        public void Jump(float jumpForce)
        {
            
        }
        
        private void SetupJumpParameters()
        {
            var timeToApex = maxJumpTime / 2f;
            gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
            initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
        }
    }
}