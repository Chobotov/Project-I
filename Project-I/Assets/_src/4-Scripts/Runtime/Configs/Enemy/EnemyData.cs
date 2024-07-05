using System;
using ProjectI.Game.Enemies;
using UnityEngine;

namespace ProjectI.Configs.Enemy
{
    [Serializable]
    public class EnemyData
    {
        [SerializeField] private EnemyType type;
        [SerializeField] private GameObject view;

        public EnemyType Type => type;
        public GameObject View => view;
    }
}