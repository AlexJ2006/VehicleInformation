using System.Runtime.CompilerServices;

namespace VehicleInfo
{
    //Base class for the Binary files
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

            //For each variabel (key), (unique part of each item) within the dictionary 
            foreach(var kvp in dict)
            {
                //Write the value of the key into the file.
                bw.Write(kvp.Key);
                //Save the Key Value to the binary file
                kvp.Value.SaveBinary(bw);
            }
            //Closing the file
            bw.Close();
        }

        public static Dictionary<string , T> LoaderDictionary <T>(string filepath)
        where T : Vehicle, new()
        {
            Dictionary<string, T> dict = new Dictionary<string, T>();
            
            FileStream fs = File.Open(filepath, FileMode.Open);
            BinaryReader br =  new BinaryReader(fs);

            int count = br.ReadInt32();

            int i = 0;

            //While "count" is larger than i...
            while (i < count)
            {
                i++; //first, increase i by 1 each time the loop runs.
                string key = br.ReadString(); //Read they key from the binary file.

                T vehicle = new T(); //Create a new instance of the vehicle
                vehicle.LoadBinary(br); //Load the vehicle into the binary file.

                dict[key] = vehicle;
            }
            //Closing the file.
            fs.Close();
            return dict;
        }
    }
}