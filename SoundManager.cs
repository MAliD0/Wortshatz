using NAudio.Vorbis;
using NAudio.Wave;
using NVorbis;

namespace Final_app
{
    public class SoundManager
    {
        private WaveOutEvent outputDevice;
        private VorbisWaveReader vorbisReader;

        string pathToSounds;

        public SoundManager(string path)
        {
            pathToSounds = path + @"Sounds\";
        }
        public void PlaySound(SoundTypes soundType)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            outputDevice = new WaveOutEvent();
            vorbisReader = new VorbisWaveReader(pathToSounds+soundType.ToString() +".ogg");
            outputDevice.Init(vorbisReader);
            outputDevice.Play();
        }
    }
    public enum SoundTypes
    {
        confirmation,
        error,
        record,  
    }
}