using ProjectI.Game;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Utills
{
    public class RestartZone : MonoBehaviour
    {
        [SerializeField] private GameLogic logic;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerController>(out _))
            {
                logic.RestartPlayer();
            }
        }
    }
}