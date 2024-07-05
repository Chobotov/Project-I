using System.Collections.Generic;
using System.Linq;
using ProjectI.Game.Enemies;
using UnityEngine;

namespace ProjectI.Configs.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Game/Configs/Enemy", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyAI enemyPrefab;
        [SerializeField] private List<EnemyData> enemyData = new();

        public EnemyAI EnemyPrefab => enemyPrefab;

        public EnemyData GetData(EnemyType type)
        {
            return enemyData.FirstOrDefault(x => x.Type == type);
        }
    }
}