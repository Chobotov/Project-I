using UnityEngine;

namespace ProjectI.Game.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private PlayerController playerPrefab;

        private PlayerController player;

        public PlayerController Player => player;

        public void CreatePlayer(Vector3 spawnPos)
        {
            player = Instantiate(playerPrefab, spawnPos, Quaternion.identity, transform);
        }
    }
}