using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace VehicleInfo
{
    public static class CarData
    {
        public static Dictionary<string, Car> carDict = new Dictionary<string, Car>();
        private static readonly string filepath = "cars.json";

        static CarData()
        {
            if (File.Exists(filepath))
            {
                LoadJsonData();
            }
            else
            {
                AddInitialCars();
                SaveToJson();
            }
        }

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(carDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                carDict = JsonSerializer.Deserialize<Dictionary<string, Car>>(json)
                    ?? new Dictionary<string, Car>();
            }
            else
            {
                carDict = new Dictionary<string, Car>();
            }
        }

        private static void AddInitialCars()
        {
            Car c1 = new Car("Ford", "Focus", 2019, 45000, "Small", 50, "FD19FCS");
            carDict.Add(c1.GetNumberPlate()!, c1);

            Car c2 = new Car("Volkswagen", "Golf", 2021, 30000, "Medium", 70, "VW21GLF");
            carDict.Add(c2.GetNumberPlate()!, c2);

            Car c3 = new Car("BMW", "3 Series", 2020, 20000, "Large", 100, "BM20SER");
            carDict.Add(c3.GetNumberPlate()!, c3);
        }
    }

    public class Car : Vehicle
    {
        [JsonInclude]
        private string? category;

        public string? GetCategory() => category;
        public void SetCategory(string category) => this.category = category;

        public Car(string make, string model, int yearOfManufacture, int mileage,
                   string category, int pricePerDay, string numberPlate)
            : base(make, model, yearOfManufacture, mileage, pricePerDay, numberPlate)
        {
            this.category = category;
        }

        public Car() { }
    }
}



//INITIAL FORMATTING FOR THE CAR ITEMS
//Taken directly from program.cs during implementation

// //First Car (large)
// Car c1 = new Car();
// c1.make = "Ford";
// c1.model = "Galaxy";
// c1.yearOfManufacture = 2022;
// c1.mileage = 60897;
// c1.category = "Large";
// c1.pricePerDay = 150;
// c1.numberPlate = "MD62JKD";
// carDict.Add(c1.numberPlate, c1);
//Second Car (small)
// Car c2 = new Car();
// c2.make = "Dacia";
// c2.model = "Sandero";
// c2.yearOfManufacture = 2021;
// c2.mileage = 75061;
// c2.category = "Small";
// c2.pricePerDay = 80;
// c2.numberPlate = "DL21OLP";
// carDict.Add(c2.numberPlate, c2);
// //Third Car (Medium)
// Car c3 = new Car();
// c3.make = "Nissan";
// c3.model = "Quashqai";
// c3.yearOfManufacture = 2020;
// c3.mileage = 50982;
// c3.category = "Medium";
// c3.pricePerDay = 120;
// c3.numberPlate = "NM60LDS";
// carDict.Add(c3.numberPlate, c3);
//Fourth Car (small)
// Car c4 = new Car();
// c4.make = "Smart";
// c4.model = "ForFour";
// c4.yearOfManufacture = 2015;
// c4.mileage = 74982;
// c4.category = "Small";
// c4.pricePerDay = 85;
// c4.numberPlate = "WF15HGG";
// carDict.Add(c4.numberPlate, c4);
//Fifth Car (small)
// Car c5 = new Car();
// c5.make = "Toyota";
// c5.model = "Aygo";
// c5.yearOfManufacture = 2024;
// c5.mileage = 13521;
// c5.category = "Small";
// c5.pricePerDay = 100;
// c5.numberPlate = "MC24NEW";
// carDict.Add(c5.numberPlate, c5);
// //ADD MORE CARS HERE