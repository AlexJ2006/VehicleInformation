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
    }

    //Setting out the staff class
    public class Staff
    {
        //Using protected variables here, to maintain privacy and security
        protected int staffID { get; set; }
        protected string firstName { get; set; } = "";
        protected string lastName { get; set; } = "";
        protected string password { get; set; } = "";

        //Then, to allow the program to access the protected data whilst keeping it secure
        //Using getter and setter functions
        public string GetName() => $"{firstName} {lastName}";

        public string GetFirstName() => $"{firstName}";
        public string GetLastName() => $"{lastName}";

        public void SetID(int id) => staffID = staffID;
        public void SetFirstName(string fName) => firstName = fName;
        public void SetLastName(string lName) => lastName = lName;

        //Saving the inputted staff information to binary (writing)
        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(firstName);
            bw.Write(lastName);
            bw.Write(password);
        }
        //Reading from the binary file of current staff
        public static Staff LoadBinary(BinaryReader br)
        {
            Staff staff = new Staff
            {
                firstName = br.ReadString(),
                lastName = br.ReadString(),
                password = br.ReadString()
            };
            return staff;
        }
    }
}
