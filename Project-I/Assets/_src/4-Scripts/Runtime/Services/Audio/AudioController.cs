using UnityEngine;

namespace ProjectI.Game.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        internal void PlayMusic(AudioClip clip)
        {
            musicSource.PlayOneShot(clip);
        }

        internal void PlaySfx(AudioClip clip)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}