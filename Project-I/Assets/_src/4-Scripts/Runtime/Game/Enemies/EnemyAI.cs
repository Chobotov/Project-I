using ProjectI.Configs.Enemy;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public abstract class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform render;
        [SerializeField] private EnemyType type;

        protected AttackComponent attackComponent;
        protected IMoveble moveble;
        protected Rigidbody rigidbody;

        protected EnemyData data;

        public EnemyType Type => type;
        public Transform Render => render;

        public virtual void Init(EnemyData data)
        {
            this.data = data;
        }
    }
}