using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StoreList
{
    public static class StoreInfo
    {
        public static List<string> Stores { get; private set; } = new(5000);

        private static readonly string filePath = "storeList.json";

        // Static constructor runs once when the class is first used
        static StoreInfo()
        {
            LoadStores();
        }

        // Loads store list from JSON
        private static void LoadStores()
        {
            if (!File.Exists(filePath))
            {
                CreateDefaultJson();   // Creates file if it doesn't exist
            }

            string json = File.ReadAllText(filePath);

            try
            {
                Stores = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch
            {
                Console.WriteLine("Error reading storeList.json — creating a fresh file.");
                CreateDefaultJson();
                Stores = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath))!;
            }
        }

        // Creates the JSON file with default stores
        private static void CreateDefaultJson()
        {
            Stores = new List<string>
            {
                "London",
                "Birmingham",
                "Glasgow",
                "Liverpool",
                "Bristol",
                "Manchester",
                "Sheffield",
                "Leeds",
                "Edinburgh",
                "Leicester",
                "Coventry",
                "Bradford",
                "Cardiff"
            };

            string json = JsonSerializer.Serialize(Stores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}


//NEED TO UPDATE ANY REFERENCES TO THIS FILE SO THAT THEY WILL UOPDATE TO THE JSON
//FOR EXAMPLE WHEN ADDING STORES THEY NEED TO BE ADDED, WHEN CLEARING ETC AND REMOVING THE JSON NEEDS TO BE UPDATED

