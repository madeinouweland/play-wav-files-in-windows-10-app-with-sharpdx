using System;
using System.Collections.Generic;
using SharpDX.IO;
using SharpDX.Multimedia;
using SharpDX.XAudio2;
using System.Threading.Tasks;

namespace WaveDemo.Audio {
    public class WavePlayer : IDisposable, IWavePlayer {
        private readonly XAudio2 _xAudio;
        private Dictionary<string, Wav> _sounds;

        public WavePlayer() {
            _xAudio = new XAudio2();
            _xAudio.StartEngine();
            var masteringVoice = new MasteringVoice(_xAudio);
            masteringVoice.SetVolume(1);
        }

        public async Task LoadWaves(string path) {
            _sounds = new Dictionary<string, Wav>();
            var streams = await WavesLoader.LoadWavesFromFolder(path);
            foreach (var stream in streams) {
                AddWave(stream.Key, stream.Value);
            }
        }

        private void AddWave(string key, NativeFileStream stream) {
            var wave = new Wav();
            var soundStream = new SoundStream(stream);
            var buffer = new AudioBuffer {
                Stream = soundStream.ToDataStream(),
                AudioBytes = (int)soundStream.Length,
                Flags = BufferFlags.EndOfStream
            };
            wave.Buffer = buffer;
            wave.DecodedPacketsInfo = soundStream.DecodedPacketsInfo;
            wave.WaveFormat = soundStream.Format;

            _sounds.Add(key, wave);
        }

        public void PlayWave(string key) {
            var wave = _sounds[key];
            var sourceVoice = new SourceVoice(_xAudio, wave.WaveFormat);
            sourceVoice.SubmitSourceBuffer(wave.Buffer, wave.DecodedPacketsInfo);
            sourceVoice.Start();
        }

        public void Dispose() {
            _xAudio.Dispose();
        }
    }
}
