using Cinemachine;
using ProjectI.Game.Levels;
using ProjectI.Game.Player;
using UnityEngine;

namespace ProjectI.Game
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera;
        [Header("Factories")]
        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private PlayerFactory playerFactory;

        private void Start()
        {
            levelFactory.CreateLevelField();
            playerFactory.CreatePlayer(levelFactory.LevelField.StartPoint.position);

            SetCameraFollow(playerFactory.Player.transform);
        }

        private void SetCameraFollow(Transform follow)
        {
            camera.Follow = follow;
        }
    }
}