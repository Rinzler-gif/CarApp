using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CefSharp;
using CefSharp.Wpf;

namespace CarApp
{
    public partial class VideoDetailsPage : Page
    {
        private Video _video;

        public VideoDetailsPage(Video video)
        {
            InitializeComponent();
            _video = video ?? throw new ArgumentNullException(nameof(video));
            LoadVideoDetails();
        }

        private void LoadVideoDetails()
        {
            // Отримуємо ідентифікатор відео з URL
            string videoId = GetYouTubeVideoId(_video.Url);

            // Формуємо URL для вставки відео через iframe
            string embedUrl = $"https://www.youtube.com/embed/{videoId}";

            // Встановлюємо URL у ChromiumWebBrowser для відображення лише відео
            VideoPlayer.Address = embedUrl;

            // Встановлення заголовку та опису відео
            TitleBlock.Text = _video.Title;
            DescriptionBlock.Text = _video.Description;
        }

        // Метод для отримання ідентифікатора відео з повного URL
        private string GetYouTubeVideoId(string url)
        {
            try
            {
                var uri = new Uri(url);
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                return query["v"];
            }
            catch
            {
                // Обробка помилки або повернення значення за замовчуванням
                return string.Empty;
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Повернення до попередньої сторінки
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}