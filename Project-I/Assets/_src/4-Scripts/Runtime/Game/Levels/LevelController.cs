using UnityEngine;

namespace ProjectI.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform endPoint;

        public Transform StartPoint => startPoint;
        public Transform EndPoint => endPoint;
    }
}