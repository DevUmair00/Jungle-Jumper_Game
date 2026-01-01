using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameFrameWork.Entities;
using GameFrameWork.Component;
using GameFrameWork.Core;
using GameFrameWork.Extentions;
using GameFrameWork.Interfaces;
using GameFrameWork.Movements;
using GameFrameWork.System;

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
