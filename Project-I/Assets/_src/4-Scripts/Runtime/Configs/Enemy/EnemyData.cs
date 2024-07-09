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
        [Header("Stats")]
        [SerializeField] private int health = 100;
        [SerializeField] private float speed = 100;

        public EnemyType Type => type;
        public GameObject View => view;

        public int Health => health;
        public float Speed => speed;
    }
}