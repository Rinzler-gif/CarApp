using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CarApp
{
    public partial class CarDetailsPage : Page
    {
        private Car _selectedCar;

        public CarDetailsPage(Car selectedCar)
        {
            InitializeComponent();
            _selectedCar = selectedCar;
            DisplayCarDetails();
        }

        private void DisplayCarDetails()
        {
            // Заповнюємо поля сторінки на основі вибраного автомобіля
            Brand.Text = _selectedCar.Brand;
            Model.Text = _selectedCar.Model;
            Generation.Text = _selectedCar.Generation;
            ProductionYears.Text = _selectedCar.ProductionYears;
            BodyType.Text = _selectedCar.BodyType;
            Engine.Text = _selectedCar.Engine;
            Transmission.Text = _selectedCar.Transmission;
            Weight.Text = _selectedCar.Weight;
            Description.Text = _selectedCar.Description;

            // Завантажуємо зображення автомобіля
            if (!string.IsNullOrEmpty(_selectedCar.Image1Url))
            {
                Image1.Source = new BitmapImage(new Uri(_selectedCar.Image1Url));
            }

            if (!string.IsNullOrEmpty(_selectedCar.Image2Url))
            {
                Image2.Source = new BitmapImage(new Uri(_selectedCar.Image2Url));
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            // Повертаємось до попередньої сторінки
            NavigationService.GoBack();
        }
    }
}