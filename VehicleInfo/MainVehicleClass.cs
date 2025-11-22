using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace VehicleInfo
{
    public static class VehicleManager
    {
        public static Dictionary<string, Vehicle> vehicleDict = new();
        private static readonly string filepath = "vehicles.json";

        // Save vehicles to the JSON file.
        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(vehicleDict, options);
            File.WriteAllText(filepath, json);
        }

        // Load cars from JSON file into memory
        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                vehicleDict = JsonSerializer.Deserialize<Dictionary<string, Vehicle>>(json)
                          ?? new Dictionary<string, Vehicle>();
            }
            else
            {
                vehicleDict = new Dictionary<string, Vehicle>();
            }
        }
    }

    public class Vehicle
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

