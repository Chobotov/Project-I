using Cinemachine;
using Cysharp.Threading.Tasks;
using ProjectI.Game.Audio;
using ProjectI.Game.Enemies;
using ProjectI.Game.Levels;
using ProjectI.Game.Player;
using ProjectI.Utills;
using UniRx;
using UnityEngine;
using VContainer;

namespace ProjectI.Game
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera;
        [Header("Factories")]
        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private PlayerFactory playerFactory;
        [SerializeField] private EnemyFactory enemyFactory;

        private IAudioService audioService;

        [Inject]
        public void Inject(IAudioService service)
        {
            audioService = service;

            audioService.PlayMusic(AudioKeys.MusicTestLevel);
        }

        private void Start()
        {
            levelFactory.CreateLevelField();
            playerFactory.CreatePlayer(levelFactory.LevelField.StartPoint.position);

            CreateEnemies();
            SetCameraFollow(playerFactory.Player.transform);

            playerFactory.Player.OnPlayerDie
                .Subscribe(OnPlayerDie)
                .AddTo(playerFactory.Player);
        }

        private async void Restart()
        {
            playerFactory.Clear();

            await UniTask.Delay(15 * 100);

            audioService.PlayMusic(AudioKeys.MusicTestLevel);

            enemyFactory.Clear();

            playerFactory.CreatePlayer(levelFactory.LevelField.StartPoint.position);

            CreateEnemies();
            SetCameraFollow(playerFactory.Player.transform);

            playerFactory.Player.OnPlayerDie
                .Subscribe(OnPlayerDie)
                .AddTo(this);
        }

        private void OnPlayerDie(Null obj)
        {
            RestartPlayer();
        }

        public void RestartPlayer()
        {
            Restart();
        }

        private void CreateEnemies()
        {
            var levelPoints = levelFactory.LevelField.EnemiesPoints;

            foreach (var point in levelPoints)
            {
                enemyFactory.SpawnEnemy(point.Type, point);
            }
        }

        private void SetCameraFollow(Transform follow)
        {
            camera.Follow = follow;
        }
    }
}