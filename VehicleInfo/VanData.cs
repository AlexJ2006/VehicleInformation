using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using VehicleInfo;

namespace VanInfo
{
    public static class VanData
    {
        public static Dictionary<string, Van> vanDict = new Dictionary<string, Van>();
        private static readonly string filepath = "vans.json";

        static VanData()
        {
            if (File.Exists(filepath))
            {
                LoadJsonData();
            }
            else
            {
                AddInitialVans();
                SaveToJson();
            }
        }

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(vanDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                vanDict = JsonSerializer.Deserialize<Dictionary<string, Van>>(json)
                    ?? new Dictionary<string, Van>();
            }
            else
            {
                vanDict = new Dictionary<string, Van>();
            }
        }

        private static void AddInitialVans()
        {
            Van v1 = new Van("Mercedes", "Sprinter", 2019, 125927, "Large", 200, "MD69SPR");
            vanDict.Add(v1.GetNumberPlate()!, v1);

            Van v2 = new Van("Volkswagen", "Caddy", 2023, 56929, "Small", 200, "VW23MDS");
            vanDict.Add(v2.GetNumberPlate()!, v2);

            Van v3 = new Van("Ford", "Transit", 2020, 84562, "Small", 180, "BM28JHS");
            vanDict.Add(v3.GetNumberPlate()!, v3);

            Van v4 = new Van("Renault", "Kangoo", 2023, 98233, "Small", 185, "JD82DSK");
            vanDict.Add(v4.GetNumberPlate()!, v4);
        }
    }

    public class Van : Vehicle
    {
        [JsonInclude]
        private string? category;

        public string? GetCategory() => category;
        public void SetCategory(string category) => this.category = category;

        public Van() { }

        public Van(string make, string model, int year, int mileage, string category, int price, string plate)
            : base(make, model, year, mileage, price, plate)
        {
            this.category = category;
        }
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