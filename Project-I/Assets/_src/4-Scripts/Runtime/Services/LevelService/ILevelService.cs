namespace ProjectI.Game.Levels
{
    public interface ILevelService
    {
        int CurrentLevel { get; }

        LevelController GetLevelField();
    }
}