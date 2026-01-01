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

namespace GameFrameWork.Core
{
    public class AudioTrack
    {
        public string Name { get; set; } = null!;
        public string FilePath { get; set; }=null!;
        public float Volume { get; set; }
        public bool Loop { get; set; } 
        public float Duration { get; set; }
        public AudioTrack(string name, string filePath,bool loop)
        {
            Name = name;
            FilePath = filePath;
            Volume = 1f;
            Loop = loop;
            Duration = 0f;
        }
    }
}
