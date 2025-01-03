﻿using System.Collections.Generic;
using UnityEngine;

namespace ProjectI.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;
        [Space]
        [SerializeField] private List<CoinSpawnPoint> coinPoints;
        [SerializeField] private List<EnemySpawnPoint> enemiesPoints;

        public Transform StartPoint => startPoint;
        public Transform EndPoint => endPoint;

        public IReadOnlyCollection<CoinSpawnPoint> CoinPoints => coinPoints;
        public IReadOnlyCollection<EnemySpawnPoint> EnemiesPoints => enemiesPoints;

        [ContextMenu("Find all coins")]
        private void FindAllCoins()
        {
            var coins = transform.GetComponentsInChildren<CoinSpawnPoint>();

            coinPoints = new(coins);
        }

        [ContextMenu("Find all enemies")]
        private void FindAllEnemies()
        {
            var enemies = transform.GetComponentsInChildren<EnemySpawnPoint>();

            enemiesPoints = new(enemies);
        }
    }
}