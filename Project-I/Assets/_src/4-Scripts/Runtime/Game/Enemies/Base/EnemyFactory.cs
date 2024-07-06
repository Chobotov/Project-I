using ProjectI.Configs.Enemy;
using UnityEngine;
using VContainer;

namespace ProjectI.Game.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        private EnemyConfig config;

        [Inject]
        public void Inject(EnemyConfig config)
        {
            this.config = config;
        }

        public EnemyAI SpawnEnemy(EnemyType type, Vector3 spawnPosition)
        {
            var data = config.GetData(type);

            var enemy = Instantiate(config.EnemyPrefab, spawnPosition, Quaternion.identity, transform);
            Instantiate(data.View, enemy.Render);

            enemy.Init(data);

            return enemy;
        }
    }
}