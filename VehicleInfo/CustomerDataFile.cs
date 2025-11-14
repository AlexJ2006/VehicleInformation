using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.Json;

namespace VehicleInfo
{
    public static class CustomerData
    {
        public static Dictionary<int, Customer> customerDict = new();
        private static readonly string filepath = "customer.json";

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(customerDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                customerDict = JsonSerializer.Deserialize<Dictionary<int, Customer>>(json)
                ?? new Dictionary<int, Customer>();
            }
        }
    }

    public class Customer
    {
        private int userID { get; set; }
        private string firstName { get; set; } = "";
        private string lastName { get; set; } = "";
        private string DoB;

        private int contactNumber;
        private string password { get; set; } = "";

        public string GetName() => $"{firstName} {lastName}";
        public string GetUserID() => $"{userID}";

        public string GetDoB() => $"{DoB}";

        public string GetContactNumber() => $"{contactNumber}";        
        public string GetPassword() => $"{password}";

        public void SetUserID(int userID) { this.userID = userID; }

        public void SetFirstName(string newFirstName) { firstName = newFirstName; }

        public void SetLastName(string newLastName) { lastName = newLastName; }

        public void SetDoB(string newDoB) { DoB = newDoB; }
        
        public void SetContactNumber(int newContactNumber) { contactNumber = newContactNumber; }
        public void SetPassword(string newPassword) { password = newPassword; }
    }
}
