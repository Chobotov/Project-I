namespace ProjectI.Game.Audio
{
    public class AudioService : IAudioService
    {
        private readonly AudioConfig config;
        private readonly AudioController controller;

        public AudioService(
            AudioConfig config,
            AudioController controller)
        {
            this.config = config;
            this.controller = controller;
        }

        public void PlayMusic(AudioKeys key)
        {
            var data = config.GetAudio(key);

            controller.PlayMusic(data.Clip);
        }

        public void StopMusic()
        {
            controller.StopMusic();
        }

        public void PlaySfx(AudioKeys key)
        {
            var data = config.GetAudio(key);

            controller.PlaySfx(data.Clip);
        }
    }
}