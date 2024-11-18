using System.Windows;
using System.Windows.Controls;

namespace CarApp
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void GoToCarsSection(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarsSection());
        }

        private void GoToVideosSection(object sender, RoutedEventArgs e)
        {
            var videos = DataManager.LoadVideos();
            if (videos == null || !videos.Any())
            {
                MessageBox.Show("Відео не знайдено.");
                return;
            }
            NavigationService.Navigate(new VideosSection(videos));
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}