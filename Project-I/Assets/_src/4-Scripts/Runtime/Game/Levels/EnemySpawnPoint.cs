using ProjectI.Game.Enemies;
using UnityEngine;

namespace ProjectI.Game.Levels
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyType type;

        public EnemyType Type => type;
        public Vector3 Position => transform.position;

#if UNITY_EDITOR

        private void OnValidate()
        {
            gameObject.name = $"EnemySpawnPoint ({type})";
        }

#endif
    }
}