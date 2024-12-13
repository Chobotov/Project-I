using System.Collections.Generic;
using ProjectI.Game.Levels;
using UnityEngine;

namespace ProjectI.Configs.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "ProjectI/Configs", order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private int defaultLevel;
        [SerializeField] private List<LevelController> levels = new();

        public int DefaultLevel => defaultLevel;

        public LevelController GetLevelField(int level)
        {
            if (level < 0 || level >= levels.Count) return null;

            return levels[level];
        }
    }
}