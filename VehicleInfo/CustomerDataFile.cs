using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VehicleInfo
{
    public static class CustomerData
    {
        public static Dictionary<int, Customer> customerDict = new();
        private static readonly string filepath = "customer.json";

        public static void SaveToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(customerDict, options);
            File.WriteAllText(filepath, json);
        }

        public static void LoadJsonData()
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true
                };

                customerDict = JsonSerializer.Deserialize<Dictionary<int, Customer>>(json, options)
                               ?? new Dictionary<int, Customer>();
            }
        }
    }

    public class Customer
    {
        [JsonInclude]
        private int userID;

        [JsonInclude]
        private string firstName = "";

        [JsonInclude]
        private string lastName = "";

        [JsonInclude]
        private string DoB = "";

        [JsonInclude]
        private int contactNumber;

        [JsonInclude]
        private string password = "";

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
