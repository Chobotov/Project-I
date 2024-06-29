using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectI.Game.Audio
{
    [CreateAssetMenu(fileName = "Audio Config", menuName = "ProjectI/Configs/Audio", order = 0)]
    public class AudioConfig : ScriptableObject
    {
        [SerializeField] private List<AudioData> clips = new();

        internal AudioData GetAudio(AudioKeys key)
        {
            return clips.FirstOrDefault(x => x.Key == key);
        }
    }
}