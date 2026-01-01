using GameFrameWork;
using GameFrameWork.Core;
using GameFrameWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWork.Interfaces;

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
