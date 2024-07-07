using ProjectI.Game.Audio;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace ProjectI.Game.Player
{
    public class PlayerController : MonoBehaviour, IDamageble
    {
        private static int JumpAnimationKey = Animator.StringToHash("Jump");

        [Header("Components")] 
        [SerializeField] private Animator animator;
        [SerializeField] private CustomGravityComponent gravityComponent;
        [Space]
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private bool isGround;

        private PlayerConfig config;
        private Controls.Controls controls;

        private Rigidbody rigidbody;

        private IAudioService audioService;
        private IMoveble moveble;
        private AttackComponent attackComponent;

        private float speed;
        private float moveInput;
        private int jumpCount;

        private MoveSettings MoveSettings => config.MoveSettings;
        private bool CanJump => isGround || jumpCount < MoveSettings.DefaultJumpCount;

        [Inject]
        public void Inject(IAudioService audioService, PlayerConfig config)
        {
            this.audioService = audioService;
            this.config = config;

            speed = MoveSettings.DefaultMoveSpeed;
        }

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();

            moveble = new RigidbodyMoveBehaviour(rigidbody);
            attackComponent = new RotateAttack(transform, animator);
            controls = new Controls.Controls();
        }

        private void OnEnable()
        {
            controls.Main.Jump.performed += Jump;
            controls.Main.Attack.performed += Attack;

            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Main.Attack.performed -= Attack;
            controls.Main.Jump.performed -= Jump;

            controls.Disable();
        }

        private void Attack(InputAction.CallbackContext obj)
        {
            if (!isGround) return;

            audioService.PlaySfx(AudioKeys.SfxPlayerAttack);

            attackComponent.Execute();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            if (CanJump)
            {
                jumpCount++;

                var gravityValue = -gravityComponent.Gravity * gravityComponent.GravityScale;
                var force = Mathf.Sqrt(MoveSettings.JumpForce * (gravityValue) * -2) * rigidbody.mass;

                animator.SetTrigger(JumpAnimationKey);
                audioService.PlaySfx(AudioKeys.SfxPlayerJump);
                moveble.Jump(force);
            }
        }

        private void CheckGround()
        {
            isGround = Physics.Raycast(transform.position, Vector3.down, MoveSettings.GroundHeight, groundLayerMask);
        }

        private void FixedUpdate()
        {
            CheckGround();
            gravityComponent.HandleGravity(rigidbody);

            if (isGround)
            {
                speed = MoveSettings.DefaultMoveSpeed;
                jumpCount = 0;
            }
            else
            {
                speed = MoveSettings.FallMoveSpeed;
            }

            moveInput = controls.Main.Move.ReadValue<float>();
            moveble.Move(moveInput, speed);
        }

        private int health;
        public int Health => health;
        public void SetDamage(int damage)
        {
            health = health -= damage;

            if (health <= 0)
            {
                health = 0;
            }
        }
    }
}