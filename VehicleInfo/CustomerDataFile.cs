using System;
using System.Collections.Generic;
using System.IO;

namespace VehicleInfo
{
    public static class CustomerData
    {
        public static Dictionary<int, Customer> customerDict = new();
        private static readonly string filepath = "customer.bin";

        public static void SaveToBinary()
        {
            using FileStream cfs = File.Open(filepath, FileMode.Create);
            using BinaryWriter cbw = new BinaryWriter(cfs);
        
            cbw.Write(customerDict.Count);

            foreach (var pair in customerDict)
            {
                cbw.Write(pair.Key);
                pair.Value.SaveBinary(cbw);
            }
        }

        public static void LoadFromBinary()
        {
            customerDict = new Dictionary<int, Customer>();

            if (!File.Exists(filepath))
                return;

            using FileStream cfs = File.Open(filepath, FileMode.Open);
            using BinaryReader cbr = new BinaryReader(cfs);

            int count = cbr.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                int key = cbr.ReadInt32();

                Customer c = new Customer();
                c.LoadBinary(cbr);

                customerDict[key] = c;
            }
        }
    }

    public class Customer
    {
        private int userID;
        private string firstName = "";
        private string lastName = "";
        private string DoB = "";
        private int contactNumber;
        private string password = "";

        public string GetName() => $"{firstName} {lastName}";
        public string GetUserID() => $"{userID}";
        public string GetDoB() => $"{DoB}";
        public string GetContactNumber() => $"{contactNumber}";
        public string GetPassword() => $"{password}";

        public void SetUserID(int userID) => this.userID = userID;
        public void SetFirstName(string newFirstName) => firstName = newFirstName;
        public void SetLastName(string newLastName) => lastName = newLastName;
        public void SetDoB(string newDoB) => DoB = newDoB;
        public void SetContactNumber(int newContactNumber) => contactNumber = newContactNumber;
        public void SetPassword(string newPassword) => password = newPassword;
     
        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(userID);
            bw.Write(firstName);
            bw.Write(lastName);
            bw.Write(DoB);
            bw.Write(contactNumber);
            bw.Write(password);
        }

        public void LoadBinary(BinaryReader br)
        {
            userID = br.ReadInt32();
            firstName = br.ReadString();
            lastName = br.ReadString();
            DoB = br.ReadString();
            contactNumber = br.ReadInt32();
            password = br.ReadString();
        }
    }
}
