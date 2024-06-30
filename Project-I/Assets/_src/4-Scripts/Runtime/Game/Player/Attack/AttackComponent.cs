using UnityEngine;

namespace ProjectI.Game.Player
{
    public abstract class AttackComponent
    {
        protected static int AttackAnimationKey = Animator.StringToHash("Attack");

        public abstract void Execute();
    }
}