namespace ProjectI.Game.Audio
{
    public interface IAudioService
    {
        void PlayMusic(AudioKeys key);
        void PlaySfx(AudioKeys key);
    }
}