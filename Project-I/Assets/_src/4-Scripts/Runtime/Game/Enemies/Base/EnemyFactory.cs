using System;
using System.Collections.Generic;
using ProjectI.Configs.Enemy;
using ProjectI.Game.Levels;
using UniRx;
using UnityEngine;
using VContainer;

namespace ProjectI.Game.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        private List<EnemyAI> enemies = new();

        private EnemyConfig config;

        [Inject]
        public void Inject(EnemyConfig config)
        {
            this.config = config;
        }
    
        public EnemyAI SpawnEnemy(EnemyType type, EnemySpawnPoint point)
        {
            var data = config.GetData(type);

            var enemy = Instantiate(config.EnemyPrefab, point.Position, Quaternion.identity, transform);
            Instantiate(data.View, enemy.Render);

            enemy.gameObject.name = $"{config.EnemyPrefab.name} | {Guid.NewGuid()}";

            enemy.Init(data, point);

            enemy.OnDie
                .Subscribe(OnEnemyDie)
                .AddTo(enemy);

            enemies.Add(enemy);

            return enemy;
        }

        private void OnEnemyDie(EnemyAI enemy)
        {
            enemies.Remove(enemy);
        }

        public void Clear()
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];

                if (enemy)
                {
                    Destroy(enemy.gameObject);
                }
            }

            enemies.Clear();
        }
    }
}