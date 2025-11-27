using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    //Adding the admin data so that admin can be separately logged in (and access different functions)
    public static class AdminData
    {
        public static Dictionary<int, Admin> adminDict = new(); //Creating a admin dictionary using the ID as the key
        private static readonly string filepath = "admin.bin"; //Specifying the name of the specific admin binary file

        public static void SaveToBinary() //Saving the admin details to binary (writing)
        {
            using FileStream fs = File.Open(filepath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(adminDict.Count);

            foreach (var pair in adminDict)
            {
                bw.Write(pair.Key);
                pair.Value.SaveBinary(bw);
            }
        }
        public static void LoadFromBinary() //Loading the admin details from the binary file (reading)
        {
            if (!File.Exists(filepath))
            {   
                AddInitialAdmin();
                adminDict = new Dictionary<int, Admin>();
                return;
            }

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            int count = br.ReadInt32();
            adminDict = new Dictionary<int, Admin>();

            for (int i = 0; i < count; i++)
            {
                int userID = br.ReadInt32();
                Admin admin = Admin.LoadBinary(br);
                adminDict[userID] = admin;
            }
        }
        
        private static void AddInitialAdmin()
        {
            Admin a1 = new Admin(2001, "Alex", "Jakeman");
            adminDict.Add(a1.GetUserID()!, a1);

            Admin a2 = new Admin(2002, "Freya", "Jakeman");
            adminDict.Add(a2.GetUserID()!, a2);

            Admin a3 = new Admin(2003, "Isaac", "Jakeman");
            adminDict.Add(a3.GetUserID()!, a3);

            Admin a4 = new Admin(2004, "Sophie", "Jakeman");
            adminDict.Add(a4.GetUserID()!, a4);

            SaveToBinary();
        }
    }

    //Setting out the admin class
    //Setting out the admin class
    public class Admin
    {
        //Using protected variables here, to maintain privacy and security
        protected int adminID { get; set; }
        protected string firstName { get; set; } = "";
        protected string lastName { get; set; } = "";
    
        //Then, to allow the program to access the protected data whilst keeping it secure
        //Using getter and setter functions
        public int GetUserID() => adminID;
        public string GetName() => $"{firstName} {lastName}";
        public string GetFirstName() => $"{firstName}";
        public string GetLastName() => $"{lastName}";

        public void SetID(int id) => adminID = id;
        public void SetFirstName(string fName) => firstName = fName;
        public void SetLastName(string lName) => lastName = lName;

        //Saving the inputted admin information to binary (writing)
        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(adminID);
            bw.Write(firstName);
            bw.Write(lastName);
        }

        //Reading from the binary file of current admin
        public static Admin LoadBinary(BinaryReader br)
        {
            Admin admin = new Admin(
                br.ReadInt32(),
                br.ReadString(),
                br.ReadString()
            );

            return admin;
        }
        //Adding a constructor
        public Admin(int id, string fName, string lName)
        {
            adminID = id;
            firstName = fName;
            lastName = lName;
        }
    }
}
