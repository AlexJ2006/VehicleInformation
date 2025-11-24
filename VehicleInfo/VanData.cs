using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

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
            Van v1 = new Van();
            v1.SetMake("Mercedes");
            v1.SetModel("Sprinter");
            v1.SetYear(2019);
            v1.SetMileage(125927);
            v1.SetCategory("Large");
            v1.SetPricePerDay(200);
            v1.SetNumberPlate("MD69SPR");
            vanDict.Add(v1.GetNumberPlate()!, v1);

            Van v2 = new Van();
            v2.SetMake("Volkswagen");
            v2.SetModel("Caddy");
            v2.SetYear(2023);
            v2.SetMileage(56929);
            v2.SetCategory("Small");
            v2.SetPricePerDay(200);
            v2.SetNumberPlate("VW23MDS");
            vanDict.Add(v2.GetNumberPlate()!, v2);

            Van v3 = new Van();
            v3.SetMake("Ford");
            v3.SetModel("Transit");
            v3.SetYear(2020);
            v3.SetMileage(84562);
            v3.SetCategory("Small");
            v3.SetPricePerDay(180);
            v3.SetNumberPlate("BM28JHS");
            vanDict.Add(v3.GetNumberPlate()!, v3);

            Van v4 = new Van();
            v4.SetMake("Renault");
            v4.SetModel("Kangoo");
            v4.SetYear(2023);
            v4.SetMileage(98233);
            v4.SetCategory("Small");
            v4.SetPricePerDay(185);
            v4.SetNumberPlate("JD82DSK");
            vanDict.Add(v4.GetNumberPlate()!, v4);
        }
    }

    public class Van
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
        protected string? category;
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

        public string? GetCategory() => category;
        public void SetCategory(string category) => this.category = category;

        public int GetPricePerDay() => pricePerDay;
        public void SetPricePerDay(int price) => pricePerDay = price;

        public string? GetNumberPlate() => numberPlate;
        public void SetNumberPlate(string plate) => numberPlate = plate;

        public Van() { }

        public Van(string make, string model, int year, int mileage, string category, int price, string plate)
        {
            this.make = make;
            this.model = model;
            this.yearOfManufacture = year;
            this.mileage = mileage;
            this.category = category;
            this.pricePerDay = price;
            this.numberPlate = plate;
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