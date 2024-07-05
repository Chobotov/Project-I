using System.Collections.Generic;
using UnityEngine;

namespace ProjectI.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;
        [Space]
        [SerializeField] private List<EnemySpawnPoint> enemiesPoints;

        public Transform StartPoint => startPoint;
        public Transform EndPoint => endPoint;

        public IReadOnlyCollection<EnemySpawnPoint> EnemiesPoints => enemiesPoints;
    }
}