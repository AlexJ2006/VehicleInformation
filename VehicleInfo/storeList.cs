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

        private static bool isLoaded = false;

        //Saving the stores to the JSON file.
        public static void SaveStores()
        {
            string json = JsonSerializer.Serialize(Stores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        // Loads store list from JSON
        public static void LoadStores(bool forceReload = true)
        {
            if (!forceReload && isLoaded)
                return;

            if (!File.Exists(filePath))
            {
                CreateDefaultJson();
            }

            string json = File.ReadAllText(filePath);

            try
            {
                Stores = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch
            {
                Console.WriteLine("FILE NOT FOUND. CREATING NEW FILE..");
                CreateDefaultJson();
                Stores = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(filePath))!;
            }

            isLoaded = true;
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
