using ProjectI.Game.Enemies;
using UnityEngine;

namespace ProjectI.Game.Levels
{
    public class EnemySpawnPoint : SpawnPoint
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private Transform[] movePositions;

        public EnemyType Type => type;
        public Transform[] MovePositions => movePositions;

#if UNITY_EDITOR

        private void OnValidate()
        {
            gameObject.name = $"EnemySpawnPoint ({type})";
        }

#endif
    }
}