using UnityEngine;

namespace ProjectI.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        private Rigidbody rigidbody;

        private Controls.Controls inputControls;

        private float moveInput;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            inputControls = new Controls.Controls();
        }

        private void OnEnable()
        {
            inputControls.Enable();

            inputControls.Main.Jump.performed += context => Jump();
        }

        private void OnDisable()
        {
            inputControls.Disable();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            moveInput = inputControls.Main.Move.ReadValue<float>();

            rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);
        }
        
        private void Jump()
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}