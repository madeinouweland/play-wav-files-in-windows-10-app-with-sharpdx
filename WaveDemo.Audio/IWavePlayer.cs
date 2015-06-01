using System.Threading.Tasks;

namespace WaveDemo.Audio {
    public interface IWavePlayer {
        Task LoadWaves(string path);
        void PlayWave(string key);
    }
}
