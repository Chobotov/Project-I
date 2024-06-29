using ProjectI.Game.Levels;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Utills
{
    public class RestartGame : MonoBehaviour
    {
        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private PlayerFactory playerFactory;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var spawnPos = levelFactory.LevelField.StartPoint;

                playerFactory.Player.transform.position = spawnPos.position;
            }
        }
    }
}