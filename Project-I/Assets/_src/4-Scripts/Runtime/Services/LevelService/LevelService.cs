using ProjectI.Configs.Levels;
using UniRx;

namespace ProjectI.Game.Levels
{
    public class LevelService : ILevelService
    {
        private readonly LevelsConfig config;

        private readonly IntReactiveProperty currentLevel;

        public IReadOnlyReactiveProperty<int> CurrentLevel => currentLevel;

        public LevelService(LevelsConfig config)
        {
            this.config = config;

            currentLevel = new(config.DefaultLevel);
        }

        public void CompleteLevel()
        {
            currentLevel.Value++;
        }

        public LevelController GetLevelField()
        {
            return config.GetLevelField(currentLevel.Value);
        }
    }
}