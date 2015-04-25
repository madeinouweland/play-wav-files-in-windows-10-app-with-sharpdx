using WaveDemo.Audio;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace WaveDemo {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e) {
            _wavePlayer = new WavePlayer();
            await _wavePlayer.LoadWaves(Package.Current.InstalledLocation.Path + @"\Assets\Audio");
        }

        private IWavePlayer _wavePlayer;

        private void Button_Click1(object sender, RoutedEventArgs e) {
            _wavePlayer.PlayWave("wav1.wav");
        }

        private void Button_Click2(object sender, RoutedEventArgs e) {
            _wavePlayer.PlayWave("wav2.wav");
        }
    }
}
