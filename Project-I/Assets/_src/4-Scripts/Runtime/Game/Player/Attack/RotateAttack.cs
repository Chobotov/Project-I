using UnityEngine;

namespace ProjectI.Game.Player
{
    public class RotateAttack : AttackComponent
    {
        private readonly Animator animator;

        public RotateAttack(Animator animator)
        {
            this.animator = animator;
        }

        public override void Execute()
        {
            Debug.Log($"{nameof(RotateAttack)}");

            animator.SetTrigger(AttackAnimationKey);
        }
    }
}