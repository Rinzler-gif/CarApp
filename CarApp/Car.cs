namespace CarApp
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string ProductionYears { get; set; }
        public string BodyType { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Weight { get; set; }
        public string Image1Url { get; set; }
        public string Image2Url { get; set; }
        public string Description { get; set; }

        // Конструктор для ініціалізації даних
        public Car(string brand, string model, string generation, string productionYears, string bodyType, string engine, string transmission, string weight, string image1Url, string image2Url, string description)
        {
            Brand = brand;
            Model = model;
            Generation = generation;
            ProductionYears = productionYears;
            BodyType = bodyType;
            Engine = engine;
            Transmission = transmission;
            Weight = weight;
            Image1Url = image1Url;
            Image2Url = image2Url;
            Description = description;
        }
    }
}