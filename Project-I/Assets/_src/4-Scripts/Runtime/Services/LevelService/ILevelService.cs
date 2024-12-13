using UniRx;

namespace ProjectI.Game.Levels
{
    public interface ILevelService
    {
        IReadOnlyReactiveProperty<int> CurrentLevel { get; }

        void CompleteLevel();
        LevelController GetLevelField();
    }
}