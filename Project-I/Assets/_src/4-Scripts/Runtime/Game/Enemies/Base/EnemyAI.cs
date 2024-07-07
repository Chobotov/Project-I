using DG.Tweening;
using ProjectI.Configs.Enemy;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public class EnemyAI : MonoBehaviour, IDamageble
    {
        [SerializeField] private Transform render;
        [SerializeField] private EnemyType type;

        protected AttackComponent attackComponent;
        protected IMoveble moveble;
        protected Rigidbody rigidbody;

        protected EnemyData data;

        protected int health;

        public EnemyType Type => type;
        public Transform Render => render;

        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void Init(EnemyData data)
        {
            this.data = data;
            this.type = data.Type;
        }

        public int Health => health;

        public void SetDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                health = 0;

                Die();
            }
        }

        private void Die()
        {
            var endPos = transform.position + Vector3.back * 3;
            var jumpPower = 3f;
            var jumpCount = 1;
            var duration = .5f;
 
            DOTween.Sequence()
                .AppendCallback(() => transform.DOScale(Vector3.zero, duration))
                .AppendCallback(() => transform.DORotate(Vector3.one * 180f, duration, RotateMode.FastBeyond360).SetLoops(-1))
                .Append(transform.DOJump(endPos, jumpPower, jumpCount, duration))
                .OnComplete(() => Destroy(gameObject));
        }
    }
}