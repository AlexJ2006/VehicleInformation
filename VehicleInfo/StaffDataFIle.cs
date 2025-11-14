using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VehicleInfo
{
    public static class StaffData
    {
        public static Dictionary<int, Staff> staffDict = new();
        private static readonly string filepath = "staff.json";

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(staffDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                staffDict = JsonSerializer.Deserialize<Dictionary<int, Staff>>(json)
                ?? new Dictionary<int, Staff>();
            }
        }
    }

    public class Staff
    {
        public int staffID { get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";

        public string password { get; set; } = "";

        public string GetName() => $"{firstName} {lastName}";
    }
}
