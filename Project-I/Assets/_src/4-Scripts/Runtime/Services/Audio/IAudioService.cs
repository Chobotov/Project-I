namespace ProjectI.Game.Audio
{
    public interface IAudioService
    {
        void PlayMusic(AudioKeys key);
        void StopMusic();

        void PlaySfx(AudioKeys key);
    }
}