using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarApp
{
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            this.KeyDown += OnKeyDownHandler;
            this.Focusable = true;
            this.Focus();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigationService.Navigate(new MainMenu());
            }
        }
    }
}