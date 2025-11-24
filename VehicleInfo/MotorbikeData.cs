using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace MotorbikeInfo
{
    public static class MotorbikeData
    {
        public static Dictionary<string, Motorbike> motorbikeDict = new Dictionary<string, Motorbike>();
        private static readonly string filepath = "motorbikes.json";

        static MotorbikeData()
        {
            if (File.Exists(filepath))
            {
                LoadJsonData();
            }
            else
            {
                AddInitialMotorbikes();
                SaveToJson();
            }
        }

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(motorbikeDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                motorbikeDict = JsonSerializer.Deserialize<Dictionary<string, Motorbike>>(json)
                    ?? new Dictionary<string, Motorbike>();
            }
            else
            {
                motorbikeDict = new Dictionary<string, Motorbike>();
            }
        }

        private static void AddInitialMotorbikes()
        {
            Motorbike b1 = new Motorbike();
            b1.SetMake("Harley Davidson");
            b1.SetModel("RoadGlide");
            b1.SetYear(2023);
            b1.SetMileage(25856);
            b1.SetPricePerDay(200);
            b1.SetNumberPlate("HD23LOW");
            motorbikeDict.Add(b1.GetNumberPlate()!, b1);

            Motorbike b2 = new Motorbike();
            b2.SetMake("BMW");
            b2.SetModel("F900 GS");
            b2.SetYear(2025);
            b2.SetMileage(1298);
            b2.SetPricePerDay(180);
            b2.SetNumberPlate("BM25SPD");
            motorbikeDict.Add(b2.GetNumberPlate()!, b2);

            Motorbike b3 = new Motorbike();
            b3.SetMake("BMW");
            b3.SetModel("R1300 GS Adventure");
            b3.SetYear(2024);
            b3.SetMileage(11092);
            b3.SetPricePerDay(200);
            b3.SetNumberPlate("SP24LOR");
            motorbikeDict.Add(b3.GetNumberPlate()!, b3);

            Motorbike b4 = new Motorbike();
            b4.SetMake("Honda");
            b4.SetModel("RoadGlide");
            b4.SetYear(2019);
            b4.SetMileage(28933);
            b4.SetPricePerDay(200);
            b4.SetNumberPlate("HN19DAR");
            motorbikeDict.Add(b4.GetNumberPlate()!, b4);
        }
    }

    public class Motorbike
    {
        [JsonInclude]
        protected string? make;
        [JsonInclude]
        protected string? model;
        [JsonInclude]
        protected int yearOfManufacture;
        [JsonInclude]
        protected int mileage;
        [JsonInclude]
        protected int pricePerDay;
        [JsonInclude]
        protected string? numberPlate;

        public string? GetMake() => make;
        public void SetMake(string make) => this.make = make;

        public string? GetModel() => model;
        public void SetModel(string model) => this.model = model;

        public int GetYear() => yearOfManufacture;
        public void SetYear(int year) => yearOfManufacture = year;

        public int GetMileage() => mileage;
        public void SetMileage(int mileage) => this.mileage = mileage;

        public int GetPricePerDay() => pricePerDay;
        public void SetPricePerDay(int price) => pricePerDay = price;

        public string? GetNumberPlate() => numberPlate;
        public void SetNumberPlate(string plate) => numberPlate = plate;

        public Motorbike() { }

        public Motorbike(string make, string model, int year, int mileage, int price, string plate)
        {
            this.make = make;
            this.model = model;
            this.yearOfManufacture = year;
            this.mileage = mileage;
            this.pricePerDay = price;
            this.numberPlate = plate;
        }
    }
}


//Motorbike List as taken directly from program.cs during implementation

// Motorbikes
// //First Bike
// Motorbike b1 = new Motorbike();
// b1.make = "Harley Davidson";
// b1.model = "RoadGlide";
// b1.yearOfManufacture = 2023;
// b1.mileage = 25856;
// b1.pricePerDay = 200;
// b1.numberPlate = "HD23LOW";
// motorbikeDict.Add(b1.numberPlate, b1);
// Second Bike
// Motorbike b2 = new Motorbike();
// b2.make = "BMW";
// b2.model = "F900 GS";
// b2.yearOfManufacture = 2025;
// b2.mileage = 1298;
// b2.pricePerDay = 180;
// b2.numberPlate = "BM25SPD";
// motorbikeDict.Add(b2.numberPlate, b2);
// Third Bike
// Motorbike b3 = new Motorbike();
// b3.make = "BMW";
// b3.model = "R1300 GS Adventure";
// b3.yearOfManufacture = 2024;
// b3.mileage = 11092;
// b3.pricePerDay = 200;
// b3.numberPlate = "SP24LOR";
// motorbikeDict.Add(b3.numberPlate, b3);
// //Fourth Bike
// Motorbike b4 = new Motorbike();
// b4.make = "Honda";
// b4.model = "RoadGlide";
// b4.yearOfManufacture = 2019;
// b4.mileage = 28933;
// b4.pricePerDay = 200;
// b4.numberPlate = "HN19DAR";
// motorbikeDict.Add(b4.numberPlate, b4);
// //ADD MORE MOTORBIKES HERE
