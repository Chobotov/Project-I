using UnityEngine;

namespace ProjectI.Game.Player
{
    public class RotateAttack : AttackComponent
    {
        private readonly LayerMask playerMask = LayerMask.NameToLayer("Player");

        private const int HitsCount = 2; 
        private readonly RaycastHit[] hits = new RaycastHit[HitsCount]; 

        private readonly float radius = 3f;

        private readonly Transform transform;
        private readonly Animator animator;

        public RotateAttack(Transform transform, Animator animator)
        {
            this.transform = transform;
            this.animator = animator;
        }

        public override void Execute()
        {
            Debug.Log($"{nameof(RotateAttack)}");

            PerformAttack();

            animator.SetTrigger(AttackAnimationKey);
        }

        protected override void PerformAttack()
        {
            var direction = transform.rotation.eulerAngles.y == 0
                ? Vector3.right
                : Vector3.left;

            var ray = new Ray(transform.position, direction);
            var hitsCount = Physics.SphereCastNonAlloc(ray, radius, hits, maxDistance: radius, layerMask: playerMask);

            if (hitsCount > 0)
            {
                Debug.Log($"Perform Attack : Hits Count {hitsCount}");

                foreach (var hit in hits)
                {
                    if (hit.transform == null) continue;

                    Debug.Log($"Perform Attack : Try Perform Attack To {hit.transform.name}");

                    var parent = hit.transform.parent.parent;

                    if (parent.TryGetComponent<IDamageble>(out var damageble))
                    {
                        damageble.SetDamage(100);

                        Debug.Log($"Perform Attack : Attack To {hit.transform.name}");
                    }
                }
            }
        }
    }
}