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

namespace GameFrameWork.Component
{
    public class Audio:IAudio
    {
        //sound data object
        private Dictionary<string,AudioTrack> sounds= new Dictionary<string, AudioTrack>();

        //playing devices like Speaker
        private Dictionary<string, WaveOutEvent> outputs = new();
        // File readers
        private Dictionary<string, AudioFileReader> readers = new();


        public void AddSound(AudioTrack sound)
        {
            if (!sounds.ContainsKey(sound.Name))
                sounds.Add(sound.Name, sound);
        }

        public void Play(string name)
        {
            if (!sounds.TryGetValue(name, out var track))
                return;

            // Create reader if not exists
            if (!readers.ContainsKey(name))
                readers[name] = new AudioFileReader(track.FilePath);

            // Reset playback
            readers[name].Position = 0;
            readers[name].Volume = track.Volume;

            // Create output if not exists
            if (!outputs.ContainsKey(name))
            {
                var output = new WaveOutEvent();
                output.Init(readers[name]);

                // LOOP SUPPORT
                if (track.Loop)
                {
                    output.PlaybackStopped += (s, e) =>
                    {
                        readers[name].Position = 0;
                        output.Play();
                    };
                }

                outputs[name] = output;
            }

            outputs[name].Play();
        }


        public void Stop(string name)
        {
            if (outputs.TryGetValue(name, out var output))
            {
                output.Stop();
                output.Dispose();
                outputs.Remove(name);
            }

            if (readers.TryGetValue(name, out var reader))
            {
                reader.Dispose();
                readers.Remove(name);
            }
        }

        public void StopAll()
        {
            foreach (var output in outputs.Values)
            {
                output.Stop();
                output.Dispose();
            }
            outputs.Clear();

            foreach (var reader in readers.Values)
                reader.Dispose();
            readers.Clear();
        }


        public void SetVolume(string name, float volume)
        {
            if (outputs.TryGetValue(name, out var output))
                output.Volume = volume;
            if (sounds.TryGetValue(name, out var track))
                track.Volume = volume;
        }


    }
}
