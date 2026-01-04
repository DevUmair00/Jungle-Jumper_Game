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
using NAudio.Wave;
using System.IO;

namespace GameFrameWork.Core
{
    public class AudioTrack
    {
        public string Name { get; set; } = null!;
        public string FilePath { get; set; }=null!;
        public float Volume { get; set; }
        public bool Loop { get; set; } 
        public float Duration { get; set; }


        // NAudio internals (hidden from gameplay)

        private WaveOutEvent? output;
        private AudioFileReader? reader;


        public AudioTrack(string name, string filePath,bool loop)
        {
            Name = name;
            FilePath = filePath;
            Volume = 1f;
            Loop = loop;

            Load();
        }


        // Load audio and calculate duration
        private void Load()
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"Audio file not found:\n{fullPath}");
                return;
            }

            reader = new AudioFileReader(fullPath);
            Duration = (float)reader.TotalTime.TotalSeconds;
        }



    }
}

