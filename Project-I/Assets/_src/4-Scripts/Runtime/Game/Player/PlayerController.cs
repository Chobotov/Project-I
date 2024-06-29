using ProjectI.Game.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace ProjectI.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Move settings")]
        [SerializeField] private float defaultMoveSpeed;
        [SerializeField] private float fallMoveSpeed;
        [SerializeField] private float defaultJumpCount;
        [SerializeField] private float jumpForce;
        [SerializeField] private float groundHeight;
        [Header("Stats")]
        [SerializeField] private CustomGravityComponent gravityComponent;
        [SerializeField] private bool isGround;

        private Controls.Controls controls;

        private Rigidbody rigidbody;

        private IAudioService audioService;
        private IMoveble moveble;

        private float speed;
        private float moveInput;
        private int jumpCount;

        private bool CanJump => isGround || jumpCount < defaultJumpCount;

        [Inject]
        public void Inject(IAudioService audioService)
        {
            this.audioService = audioService;
        }
        
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            moveble = new RigidbodyMoveBehaviour(rigidbody);
            controls = new Controls.Controls();

            speed = defaultMoveSpeed;
        }

        private void OnEnable()
        {
            controls.Main.Jump.performed += Jump;

            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Main.Jump.performed -= Jump;

            controls.Disable();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            if (CanJump)
            {
                var gravityValue = -gravityComponent.Gravity * gravityComponent.GravityScale;
                var force = Mathf.Sqrt(jumpForce * (gravityValue) * -2) * rigidbody.mass;
                moveble.Jump(force);

                jumpCount++;
                
                audioService.PlaySfx(AudioKeys.SfxPlayerJump);
            }
        }

        private void CheckGround()
        {
            isGround = Physics.Raycast(transform.position, Vector3.down, groundHeight);
        }

        private void FixedUpdate()
        {
            CheckGround();
            gravityComponent.HandleGravity(rigidbody);

            if (isGround)
            {
                speed = defaultMoveSpeed;
                jumpCount = 0;
            }
            else
            {
                speed = fallMoveSpeed;
            }

            moveInput = controls.Main.Move.ReadValue<float>();
            moveble.Move(moveInput, speed);
        }
    }
}