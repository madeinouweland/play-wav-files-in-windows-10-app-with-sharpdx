using SharpDX.Multimedia;
using SharpDX.XAudio2;

namespace WaveDemo.Audio {
    public class Wav {
        public AudioBuffer Buffer { get; set; }
        public uint[] DecodedPacketsInfo { get; set; }
        public WaveFormat WaveFormat { get; set; }
    }
}
