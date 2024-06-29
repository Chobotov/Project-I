using System;
using UnityEngine;

namespace ProjectI.Game.Audio
{
    [Serializable]
    public class AudioData
    {
        [SerializeField] private AudioKeys key;
        [SerializeField] private AudioClip clip;

        internal AudioKeys Key => key;

        internal AudioClip Clip => clip;
    }
}