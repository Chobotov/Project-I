using ProjectI.Configs.Enemy;
using UnityEngine;

namespace ProjectI.Game.Enemies
{
    public class EnemyFactory
    {
        private readonly EnemyConfig config;

        public EnemyFactory(EnemyConfig config)
        {
            this.config = config;
        }

        public EnemyAI SpawnEnemy(EnemyType type, Vector3 spawnPosition)
        {
            var data = config.GetData(type);

            var enemy = Object.Instantiate(config.EnemyPrefab, spawnPosition, Quaternion.identity);
            Object.Instantiate(data.View, enemy.Render);

            enemy.Init(data);

            return enemy;
        }
    }
}