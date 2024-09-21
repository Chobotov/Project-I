using UnityEngine;

namespace ProjectI.Game.Player
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "ProjectI/Configs/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private MoveSettings moveSettings;

        public MoveSettings MoveSettings => moveSettings;
    }
}