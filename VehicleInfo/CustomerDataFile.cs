using System;
using System.Collections.Generic;
using System.IO;

namespace VehicleInfo
{
    //Creating a class for the customer data
    public static class CustomerData
    {
        //Creating a new dictionary full of customers, using int as they have an ID as their primary key
        public static Dictionary<int, Customer> customerDict = new();
        private static readonly string filepath = "customer.bin";

        //Same Processa as for the vehicles
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

        //Same process as for the vehicles again here.
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

        private static void AddInitialCustomers()
        {
            Customer c1 = new Customer(2001, "Alex", "Jakeman");
            customerDict.Add(c1.GetUserID()!, c1);

            Customer c2 = new Customer(2002, "Freya", "Jakeman");
            customerDict.Add(c2.GetUserID()!, c2);

            Customer c3 = new Customer(2003, "Isaac", "Jakeman");
            customerDict.Add(c3.GetUserID()!, c3);

            Customer c4 = new Customer(2004, "Sophie", "Jakeman");
            customerDict.Add(c4.GetUserID()!, c4);

            SaveToBinary();
        }
    }

    //Outlining the customer properties
    public class Customer
    {
        //First, setting them as private.
        protected int userID;
        protected string firstName = "";
        protected string lastName = "";
        protected string DoB = "";
        protected int contactNumber;
        protected string password = "";

        //Then using public getters and setters to allow the program to access the data properly
        public string GetName() => $"{firstName} {lastName}";
        public int GetUserID() => userID;
        public string GetLastName() => $"{lastName}";
        public string GetPassword() => $"{password}";

        public void SetUserID(int userID) => this.userID = userID;
        public void SetFirstName(string newFirstName) => firstName = newFirstName;
        public void SetLastName(string newLastName) => lastName = newLastName;
     
        //Saving the customer information TO the binary file
        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(userID);
            bw.Write(firstName);
            bw.Write(lastName);
            bw.Write(DoB);
            bw.Write(contactNumber);
            bw.Write(password);
        }

        //Reading the cusomter information FROM the binary file
        public void LoadBinary(BinaryReader br)
        {
            userID = br.ReadInt32();
            firstName = br.ReadString();
            lastName = br.ReadString();
            DoB = br.ReadString();
            contactNumber = br.ReadInt32();
            password = br.ReadString();
        }

        public Customer(int id, string firstName, string lastName)
        {
            userID = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Customer() { }
    }
}
