using UnityEngine;

namespace ProjectI.Game.Player
{
    public abstract class AttackComponent
    {
        protected static int AttackAnimationKey = Animator.StringToHash("Attack");

        protected abstract void PerformAttack();

        public virtual void Execute()
        {
            PerformAttack();
        }
    }
}