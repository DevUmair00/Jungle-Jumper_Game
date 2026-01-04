using GameFrameWork.Core;

namespace GameFrameWork.Interfaces
{
    public interface IAudio
    {
        void AddSound(AudioTrack sound);
        void Play(string name);
        void Stop(string name);
        void StopAll();
        void SetVolume(string name, float volume);
    }
}
