using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarApp
{
    public partial class CarsSection : Page
    {
        private List<Car> _allCars;
        private List<Car> _filteredCars;

        public CarsSection()
        {
            InitializeComponent();
            LoadData();
            InitializeFilters();
        }

        private void LoadData()
        {
            // Завантаження даних (з файлів або іншого джерела)
            _allCars = DataManager.LoadCars();
            _filteredCars = new List<Car>(_allCars);
            UpdateCarList();
        }

        private void InitializeFilters()
        {
            // Ініціалізація ComboBox-ів (Brands, Models, BodyTypes, ProductionYears) 
            var brands = _allCars.Select(car => car.Brand).Distinct().ToList();
            BrandBox.ItemsSource = brands;

            var models = _allCars.Select(car => car.Model).Distinct().ToList();
            ModelBox.ItemsSource = models;

            var bodyTypes = _allCars.Select(car => car.BodyType).Distinct().ToList();
            BodyTypeBox.ItemsSource = bodyTypes;

            var productionYears = _allCars.Select(car => car.ProductionYears).Distinct().ToList();
            ProductionYearsBox.ItemsSource = productionYears;
        }

        private void FilterCars(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = BrandBox.SelectedItem as string;
            var selectedModel = ModelBox.SelectedItem as string;
            var selectedBodyType = BodyTypeBox.SelectedItem as string;
            var selectedProductionYear = ProductionYearsBox.SelectedItem as string;

            _filteredCars = _allCars.Where(car =>
                (string.IsNullOrEmpty(selectedBrand) || car.Brand == selectedBrand) &&
                (string.IsNullOrEmpty(selectedModel) || car.Model == selectedModel) &&
                (string.IsNullOrEmpty(selectedBodyType) || car.BodyType == selectedBodyType) &&
                (string.IsNullOrEmpty(selectedProductionYear) || car.ProductionYears == selectedProductionYear)
            ).ToList();

            UpdateCarList();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCars(null, null);
        }

        private void GoToMainMenu(object sender, RoutedEventArgs e)
        {
            // Перехід до головного меню
            NavigationService.Navigate(new MainMenu()); // Замість `MainMenuPage` вкажіть правильну сторінку
        }

        private void GoToCarDetails(object sender, SelectionChangedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                // Перехід до сторінки деталей автомобіля
                NavigationService.Navigate(new CarDetailsPage(selectedCar));
            }
        }

        private void UpdateCarList()
        {
            CarsListBox.ItemsSource = _filteredCars;
        }
    }
}