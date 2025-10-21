using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace MotorbikeInfo
{
    public static class MotorbikeData
    {
        public static Dictionary<string, Motorbike> motorbikeDict = new Dictionary<string, Motorbike>();
        private static string filepath = "motorbikes.json";

        static MotorbikeData()
        {
            LoadJsonData();

            if (File.Exists(filepath))
            {
                LoadJsonData();
            }
            else
            {
                AddInitialVars();
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
                carDict = JsonSerializer.Deserialize<Dictionary<string, Motorbike>>(json)
                ?? new Dictionary<string, Motorbike>();
            }
            else
            {
                vanDict = new Dictionary<string, Motorbike>();
            }
        }
            private static void AddInitialMotorbikes()
            {
                //First Bike
                Motorbike b1 = new Motorbike();
                b1.make = "Harley Davidson";
                b1.model = "RoadGlide";
                b1.yearOfManufacture = 2023;
                b1.mileage = 25856;
                b1.pricePerDay = 200;
                b1.numberPlate = "HD23LOW";
                motorbikeDict.Add(b1.numberPlate, b1);
                Second Bike
                Motorbike b2 = new Motorbike();
                b2.make = "BMW";
                b2.model = "F900 GS";
                b2.yearOfManufacture = 2025;
                b2.mileage = 1298;
                b2.pricePerDay = 180;
                b2.numberPlate = "BM25SPD";
                motorbikeDict.Add(b2.numberPlate, b2);
                Third Bike
                Motorbike b3 = new Motorbike();
                b3.make = "BMW";
                b3.model = "R1300 GS Adventure";
                b3.yearOfManufacture = 2024;
                b3.mileage = 11092;
                b3.pricePerDay = 200;
                b3.numberPlate = "SP24LOR";
                motorbikeDict.Add(b3.numberPlate, b3);
                //Fourth Bike
                Motorbike b4 = new Motorbike();
                b4.make = "Honda";
                b4.model = "RoadGlide";
                b4.yearOfManufacture = 2019;
                b4.mileage = 28933;
                b4.pricePerDay = 200;
                b4.numberPlate = "HN19DAR";
                motorbikeDict.Add(b4.numberPlate, b4);
                //ADD MORE MOTORBIKES HERE
            }
        }

        public class Motorbike
        {
            public string? make { get; set; }
            public string? model { get; set; }
            public int yearOfManufacture { get; set; }
            public int mileage { get; set; }
            public int pricePerDay { get; set; }
            public string? numberPlate { get; set; }
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
