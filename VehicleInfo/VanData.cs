using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace VanInfo
{
    public static class VanData
    {
        public static Dictionary<string, Van> vanDict = new Dictionary<string, Van>();
        private static string filepath = "vans.json";

        static VanData()
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
            string json = JsonSerializer.Serialize(carDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                carDict = JsonSerializer.Deserialize<Dictionary<string, Van>>(json)
                ?? new Dictionary<string, Van>();
            }
            else
            {
                vanDict = new Dictionary<string, Van>();
            }
        }
            private static void AddInitialVans()
            {
                //First Van
                Van v1 = new Van();
                v1.make = "Mercedes";
                v1.model = "Sprinter";
                v1.yearOfManufacture = 2019;
                v1.mileage = 125927;
                v1.category = "Large";
                v1.pricePerDay = 200;
                v1.numberPlate = "MD69SPR";
                vanDict.Add(v1.numberPlate, v1);
                //Second Van
                Van v2 = new Van();
                v2.make = "Volkswagen";
                v2.model = "Caddy";
                v2.yearOfManufacture = 2023;
                v2.mileage = 56929;
                v2.category = "Small";
                v2.pricePerDay = 200;
                v2.numberPlate = "VW23MDS";
                vanDict.Add(v2.numberPlate, v2);
                //Third Van
                Van v3 = new Van();
                v3.make = "Ford";
                v3.model = "Transit";
                v3.yearOfManufacture = 2020;
                v3.mileage = 84562;
                v3.category = "Small";
                v3.pricePerDay = 180;
                v3.numberPlate = "BM28JHS";
                vanDict.Add(v3.numberPlate, v3);
                //Fourth Van
                Van v4 = new Van();
                v4.make = "Renault";
                v4.model = "Kangoo";
                v4.yearOfManufacture = 2023;
                v4.mileage = 98233;
                v4.category = "Small";
                v4.pricePerDay = 185;
                v4.numberPlate = "JD82DSK";
                vanDict.Add(v4.numberPlate, v4);
                ADD MORE VANS HERE

                //MORE VANS WILL NOW BE ADDED BY THE USER TO THE JSON FILE DIRECTLY.
            }

        }

        public class Van
        {
            public string? make { get; set; }
            public string? model { get; set; }
            public int yearOfManufacture { get; set; }
            public int mileage { get; set; }
            public string? category { get; set; }
            public int pricePerDay { get; set; }
            public string? numberPlate { get; set; }
        }
    }



//VanList as taken directly from program.cs during implementation
//Vans

// First Van
// Van v1 = new Van();
// v1.make = "Mercedes";
// v1.model = "Sprinter";
// v1.yearOfManufacture = 2019;
// v1.mileage = 125927;
// v1.category = "Large";
// v1.pricePerDay = 200;
// v1.numberPlate = "MD69SPR";
// vanDict.Add(v1.numberPlate, v1);
// //Second Van
// Van v2 = new Van();
// v2.make = "Volkswagen";
// v2.model = "Caddy";
// v2.yearOfManufacture = 2023;
// v2.mileage = 56929;
// v2.category = "Small";
// v2.pricePerDay = 200;
// v2.numberPlate = "VW23MDS";
// vanDict.Add(v2.numberPlate, v2);
// //Third Van
// Van v3 = new Van();
// v3.make = "Ford";
// v3.model = "Transit";
// v3.yearOfManufacture = 2020;
// v3.mileage = 84562;
// v3.category = "Small";
// v3.pricePerDay = 180;
// v3.numberPlate = "BM28JHS";
// vanDict.Add(v3.numberPlate, v3);
// //Fourth Van
// Van v4 = new Van();
// v4.make = "Renault";
// v4.model = "Kangoo";
// v4.yearOfManufacture = 2023;
// v4.mileage = 98233;
// v4.category = "Small";
// v4.pricePerDay = 185;
// v4.numberPlate = "JD82DSK";
// vanDict.Add(v4.numberPlate, v4);
// ADD MORE VANS HERE