using UnityEngine;

namespace ProjectI.Game.Player
{
    public class PlayerRigidbodyMove : IMoveble
    {
        private readonly Rigidbody rigidbody;
        private readonly Animator animator;
        private readonly MoveSettings moveSettings;
        private readonly CustomGravityComponent gravityComponent;

        private float prevScale = 1;

        private bool isGround;
        private int jumpCount;

        public PlayerRigidbodyMove(
            Rigidbody rigidbody,
            Animator animator,
            PlayerConfig config,
            CustomGravityComponent gravityComponent)
        {
            this.rigidbody = rigidbody;
            this.animator = animator;
            moveSettings = config.MoveSettings;
        }

        public void Move(float moveInput)
        {
            var move = new Vector2(moveInput * moveSettings.DefaultMoveSpeed, rigidbody.velocity.y);
            rigidbody.velocity = move;

            UpdateRotate(moveInput);
        }

        private void UpdateRotate(float moveInput)
        {
            var rotate = moveInput > 0
                ? 1f
                : -1f;

            if (moveInput == 0) rotate = prevScale;

            rigidbody.transform.localScale = new Vector3(rotate, 1f, 1f);

            prevScale = rotate;
        }

        public void Jump()
        {
            if (CanJump())
            {
                jumpCount++;

                var gravityValue = -gravityComponent.Gravity * gravityComponent.GravityScale;
                var force = Mathf.Sqrt(moveSettings.JumpForce * (gravityValue) * -2) * rigidbody.mass;

                rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
        
        private void CheckGround()
        {
            /*isGround = Physics.Raycast(
                origin: transform.position, 
                direction: Vector3.down, 
                maxDistance: moveSettings.GroundHeight, 
                layerMask: groundLayerMask);*/
        }

        private bool CanJump() => isGround || jumpCount < moveSettings.DefaultJumpCount;
    }
}