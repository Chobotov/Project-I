using ProjectI.Configs.Levels;

namespace ProjectI.Game.Levels
{
    public class LevelService : ILevelService
    {
        private readonly LevelsConfig config;

        public int CurrentLevel { get; } = 0;

        public LevelService(LevelsConfig config)
        {
            this.config = config;
        }

        public LevelController GetLevelField()
        {
            return config.GetLevelField(CurrentLevel);
        }
    }
}