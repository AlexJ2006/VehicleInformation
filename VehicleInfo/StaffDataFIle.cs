using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    //Adding the staff data so that staff can be separately logged in (and access different functions)
    public static class StaffData
    {
        public static Dictionary<int, Staff> staffDict = new(); //Creating a staff dictionary using the ID as the key
        private static readonly string filepath = "staff.bin"; //Specifying the name of the specific staff binary file

        public static void SaveToBinary() //Saving the staff details to binary (writing)
        {
            using FileStream fs = File.Open(filepath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(staffDict.Count);

            foreach (var pair in staffDict)
            {
                bw.Write(pair.Key);
                pair.Value.SaveBinary(bw);
            }
        }
        public static void LoadFromBinary() //Loading the staff details from the binary file (reading)
        {
            if (!File.Exists(filepath))
            {   
                AddInitialStaff();
                staffDict = new Dictionary<int, Staff>();
                return;
            }

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            int count = br.ReadInt32();
            staffDict = new Dictionary<int, Staff>();

            for (int i = 0; i < count; i++)
            {
                int staffID = br.ReadInt32();
                Staff staff = Staff.LoadBinary(br);
                staffDict[staffID] = staff;
            }
        }
        
        private static void AddInitialStaff()
        {
            Staff s1 = new Staff(1001, "Alex", "Jakeman");
            staffDict.Add(s1.GetUserID()!, s1);

            Staff s2 = new Staff(1002, "Freya", "Jakeman");
            staffDict.Add(s2.GetUserID()!, s2);

            Staff s3 = new Staff(1003, "Isaac", "Jakeman");
            staffDict.Add(s3.GetUserID()!, s3);

            Staff s4 = new Staff(1004, "Sophie", "Jakeman");
            staffDict.Add(s4.GetUserID()!, s4);

            SaveToBinary();
        }
    }

    //Setting out the staff class
    //Setting out the staff class
    public class Staff
    {
        //Using protected variables here, to maintain privacy and security
        protected int staffID { get; set; }
        protected string firstName { get; set; } = "";
        protected string lastName { get; set; } = "";
    
        //Then, to allow the program to access the protected data whilst keeping it secure
        //Using getter and setter functions
        public int GetUserID() => staffID;
        public string GetName() => $"{firstName} {lastName}";
        public string GetFirstName() => $"{firstName}";
        public string GetLastName() => $"{lastName}";

        public void SetID(int id) => staffID = id;
        public void SetFirstName(string fName) => firstName = fName;
        public void SetLastName(string lName) => lastName = lName;

        //Saving the inputted staff information to binary (writing)
        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(staffID);
            bw.Write(firstName);
            bw.Write(lastName);
        }

        //Reading from the binary file of current staff
        public static Staff LoadBinary(BinaryReader br)
        {
            Staff staff = new Staff(
                br.ReadInt32(),
                br.ReadString(),
                br.ReadString()
            );

            return staff;
        }
        //Adding a constructor
        public Staff(int id, string fName, string lName)
        {
            staffID = id;
            firstName = fName;
            lastName = lName;
        }
        
        public Staff() { }
    }
}
