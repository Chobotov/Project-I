using System;
using ProjectI.Configs.Enemy;
using ProjectI.Game.Levels;
using ProjectI.Game.Player;
using UniRx;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public class EnemyAI : MonoBehaviour, IDamageble
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private Transform render;
        [SerializeField] private Collider collisionCollider;

        private readonly Subject<EnemyAI> onDie = new();

        protected IMoveble moveble;

        protected EnemyData data;

        private int health;

        public int Health => health;
        public EnemyType Type => type;
        public Transform Render => render;

        public IObservable<EnemyAI> OnDie => onDie;

        public virtual void Init(EnemyData data, EnemySpawnPoint point)
        {
            this.data = data;

            type = data.Type;
            health = data.Health;

            moveble = new EnemyMove(transform, point.MovePositions);
        }

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
            onDie.OnNext(this);

            collisionCollider.enabled = false;

            moveble.Jump(
                jumpForce: 3f,
                onFinish: () => Destroy(gameObject));
        }

        private void Update()
        {
            moveble?.Move(data.Speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
            {
                damageble.SetDamage(damageble.Health);
            }
        }
    }
}