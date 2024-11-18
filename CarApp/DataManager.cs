using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace CarApp
{
    public static class DataManager
    {
        private static readonly string CarsFilePath = "cars.json";
        private static readonly string VideosFilePath = "videos.json";

        public static void SaveCars(List<Car> cars)
        {
            try
            {
                var json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CarsFilePath, json);
            }
            catch (IOException ex)
            {
                // Обробка помилок запису файлу
                MessageBox.Show($"Помилка при збереженні даних: {ex.Message}");
            }
        }

        public static List<Car> LoadCars()
        {
            try
            {
                if (!File.Exists(CarsFilePath))
                    return new List<Car>();

                var json = File.ReadAllText(CarsFilePath);
                return JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
            }
            catch (IOException ex)
            {
                // Обробка помилок зчитування файлу
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}");
                return new List<Car>();
            }
        }

        public static void SaveVideos(List<Video> videos)
        {
            try
            {
                var json = JsonSerializer.Serialize(videos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(VideosFilePath, json);
            }
            catch (IOException ex)
            {
                // Обробка помилок запису файлу
                MessageBox.Show($"Помилка при збереженні відео: {ex.Message}");
            }
        }

        public static List<Video> LoadVideos()
        {
            try
            {
                if (!File.Exists(VideosFilePath))
                    return new List<Video>();

                var json = File.ReadAllText(VideosFilePath);
                return JsonSerializer.Deserialize<List<Video>>(json) ?? new List<Video>();
            }
            catch (IOException ex)
            {
                // Обробка помилок зчитування файлу
                MessageBox.Show($"Помилка при завантаженні відео: {ex.Message}");
                return new List<Video>();
            }
        }
    }
}