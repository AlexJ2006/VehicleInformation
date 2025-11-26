using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    public static class StaffData
    {
        public static Dictionary<int, Staff> staffDict = new();
        private static readonly string filepath = "staff.bin";

        public static void SaveToBinary()
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

        public static void LoadFromBinary()
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

    public class Staff
    {
        protected int staffID { get; set; }
        protected string firstName { get; set; } = "";
        protected string lastName { get; set; } = "";
        protected string password { get; set; } = "";

        public string GetName() => $"{firstName} {lastName}";

        public string GetFirstName() => $"{firstName}";
        public string GetLastName() => $"{lastName}";

        public void SetID(int id) => staffID = staffID;
        public void SetFirstName(string fName) => firstName = fName;
        public void SetLastName(string lName) => lastName = lName;

        public void SaveBinary(BinaryWriter bw)
        {
            bw.Write(firstName);
            bw.Write(lastName);
            bw.Write(password);
        }

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
