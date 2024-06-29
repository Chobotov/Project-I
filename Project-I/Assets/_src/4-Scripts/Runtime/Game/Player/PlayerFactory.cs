using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.Game.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private PlayerController playerPrefab;

        private IObjectResolver resolver;

        private PlayerController player;

        public PlayerController Player => player;

        [Inject]
        public void Inject(IObjectResolver resolver)
        {
            this.resolver = resolver;
        }

        public void CreatePlayer(Vector3 spawnPos)
        {
            player = Instantiate(playerPrefab, spawnPos, Quaternion.identity, transform);

            resolver.InjectGameObject(player.gameObject);
        }
    }
}