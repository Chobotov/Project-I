using ProjectI.Configs.Enemy;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform render;
        [SerializeField] private EnemyType type;

        protected AttackComponent attackComponent;
        protected IMoveble moveble;
        protected Rigidbody rigidbody;

        protected EnemyData data;

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
    }
}