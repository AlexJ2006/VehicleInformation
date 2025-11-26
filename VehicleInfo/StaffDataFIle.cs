using System;
using System.Collections.Generic;
using System.IO;

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
        public int staffID { get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string password { get; set; } = "";

        public string GetName() => $"{firstName} {lastName}";

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
