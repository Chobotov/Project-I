using System;
using ProjectI.Game.Audio;
using ProjectI.Utills;
using UniRx;
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
        [Header("Stats")]
        [SerializeField] private bool isGround;

        private readonly Subject<Null> onPlayerDie = new();

        private PlayerConfig config;
        private Controls.Controls controls;

        private Rigidbody rigidbody;

        private IAudioService audioService;
        private IMoveble moveble;
        private AttackComponent attackComponent;

        private float speed;
        private float moveInput;
        private int jumpCount;

        private int health;
        
        public int Health => health;

        private MoveSettings MoveSettings => config.MoveSettings;
        private bool CanJump => isGround || jumpCount < MoveSettings.DefaultJumpCount;

        public IObservable<Null> OnPlayerDie => onPlayerDie;

        [Inject]
        public void Inject(IAudioService audioService, PlayerConfig config)
        {
            this.audioService = audioService;
            this.config = config;

            speed = MoveSettings.DefaultMoveSpeed;
            health = config.Health;
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

        public void SetDamage(int damage)
        {
            audioService.PlaySfx(AudioKeys.SfxPlayerGetDamage);

            moveble.Jump(jumpForce: 5f);

            health -= damage;

            if (health <= 0)
            {
                health = 0;

                onPlayerDie.OnNext(null);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                var damagable = collision.gameObject.GetComponentInParent<IDamageble>();

                damagable?.SetDamage(damagable.Health);
            }
        }
    }
}