
using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    public static class BinaryVehicleFunctions
    {
        public static void SaverDictionary<T>(string filepath, Dictionary<string, T> dict)
        where T : Vehicle
        {
            FileStream file = File.Open(filepath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(file);

            bw.Write(dict.Count);

            foreach(var kvp in dict)
            {
                bw.Write(kvp.Key);
                kvp.Value.SaveBinary(bw);
            }
        }

        public static Dictionary<string , T> LoaderDictionary <T>(string filepath)
        where T : Vehicle, new()
        {
            Dictionary<string, T> dict = new Dictionary<string, T>();

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            int count = br.ReadInt32();

            int i = 0;

            while (i < count)
            {
                i++;
                string key = br.ReadString();

                T vehicle = new T();
                vehicle.LoadBinary(br);

                dict[key] = vehicle;
            }
            return dict;
        }
    }
}
