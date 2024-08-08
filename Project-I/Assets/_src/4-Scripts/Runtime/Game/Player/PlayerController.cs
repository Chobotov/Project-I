using UnityEngine;
using VContainer;

namespace ProjectI.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Controls.Controls controls;

        private IMoveble moveble;
        private IHealth health;
        private AttackComponent attackComponent;

        [Inject]
        public void Inject(
            IMoveble moveble,
            IHealth health,
            AttackComponent attackComponent)
        {
            this.moveble = moveble;
            this.health = health;
            this.attackComponent = attackComponent;
        }

        private void Awake()
        {
            controls = new Controls.Controls();
        }

        private void OnEnable()
        {
            controls.Main.Jump.performed += _ => moveble.Jump();
            controls.Main.Attack.performed += _ => attackComponent.Execute();

            controls.Enable();
        }

        private void OnDisable()
        {
            controls.Main.Jump.performed -= _ => moveble.Jump();
            controls.Main.Attack.performed -= _ => attackComponent.Execute();

            controls.Disable();
        }

        private void FixedUpdate()
        {
            var moveInput = controls.Main.Move.ReadValue<float>();
            moveble.Move(moveInput);
        }

        public void SetDamage(int damage)
        {
            health.TakeDamage(damage);
        }

        public void Die()
        {
        }
    }
}