using NAudio.Wave;
using System;
using System.Windows;

namespace CarApp
{
    public partial class MainWindow : Window
    {
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFile;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new WelcomePage());
        }

        private void PlayMusic(object sender, RoutedEventArgs e)
        {
            try
            {
                if (wavePlayer == null)
                {
                    wavePlayer = new WaveOutEvent();
                    audioFile = new AudioFileReader("Metallica_Sad_But_True_Ringtone_(by Fringster.com).mp3");
                    wavePlayer.Init(audioFile);
                }
                wavePlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing audio: {ex.Message}");
            }
        }

        private void StopMusic(object sender, RoutedEventArgs e)
        {
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
            base.OnClosed(e);
        }
    }
}