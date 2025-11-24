using System.Text.Json.Serialization;

namespace VehicleInfo
{
    public class Vehicle
    {
        [JsonInclude]
        private string? make;

        [JsonInclude]
        private string? model;

        [JsonInclude]
        private int yearOfManufacture;

        [JsonInclude]
        private int mileage;

        [JsonInclude]
        private int pricePerDay;

        [JsonInclude]
        private string? numberPlate;

        public string? GetMake() => make;
        public string? GetModel() => model;
        public int GetYearOfManufacture() => yearOfManufacture;
        public int GetMileage() => mileage;
        public int GetPricePerDay() => pricePerDay;
        public string? GetNumberPlate() => numberPlate;

        public void SetMake(string make) => this.make = make;
        public void SetModel(string model) => this.model = model;
        public void SetYearOfManufacture(int year) => yearOfManufacture = year;
        public void SetMileage(int mileage) => this.mileage = mileage;
        public void SetPricePerDay(int price) => pricePerDay = price;
        public void SetNumberPlate(string plate) => numberPlate = plate;

        public Vehicle(string make, string model, int yearOfManufacture,
                       int mileage, int pricePerDay, string numberPlate)
        {
            this.make = make;
            this.model = model;
            this.yearOfManufacture = yearOfManufacture;
            this.mileage = mileage;
            this.pricePerDay = pricePerDay;
            this.numberPlate = numberPlate;
        }

        public Vehicle() { }
    }
}
