using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    //Base class for the changing of JSON files to binary files (replacign the JSON logic currently in place)
    public static class BinaryVehicleFunctions
    {
        //Create a new dictionary instance
        public static void SaverDictionary<T>(string filepath, Dictionary<string, T> dict)
        where T : Vehicle
        {
            //Attempt to open the file, if not (it doesn't exist) create a new file under the filepath.
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