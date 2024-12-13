using UnityEngine;

namespace ProjectI.Game.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        internal void PlayMusic(AudioClip clip)
        {
            StopMusic();

            musicSource.PlayOneShot(clip);
        }

        internal void StopMusic()
        {
            musicSource.Stop();
        }

        internal void PlaySfx(AudioClip clip)
        {
            sfxSource.Stop();
            sfxSource.PlayOneShot(clip);
        }
    }
}