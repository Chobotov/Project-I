using UnityEngine;

namespace ProjectI.Game.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        internal void PlayMusic(AudioClip clip)
        {
            musicSource.Stop();
            musicSource.PlayOneShot(clip);
        }

        internal void PlaySfx(AudioClip clip)
        {
            if (sfxSource.isPlaying) return;

            sfxSource.Stop();
            sfxSource.PlayOneShot(clip);
        }
    }
}