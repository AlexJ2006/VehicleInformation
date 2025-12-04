using VehicleInfo;

namespace MotorbikeInfo
{
    //Generating the Motorbike Data
    public static class MotorbikeData
    {
        //Creating a new dictionary for the motorbikes
        public static Dictionary<string, Motorbike> motorbikeDict = new Dictionary<string, Motorbike>();
        private static readonly string filepath = "motorbikes.bin"; //Specifying the filepath for the motorbikes

        private static bool isLoaded = false;
       
        //Saving the motorbikes to binary
        public static void SaveToBinary()
        {
            using FileStream fs = File.Open(filepath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(motorbikeDict.Count);

            foreach (var pair in motorbikeDict)
            {
                bw.Write(pair.Key);
                pair.Value.SaveBinary(bw);
            }
        }
        //Loading the motorbikes from binary
        public static void LoadFromBinary(bool forceRelaod = false)
        {
            if(isLoaded && !forceRelaod)
            {
                return;
            }

            motorbikeDict = new Dictionary<string, Motorbike>();

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            int count = br.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                string key = br.ReadString();

                Motorbike m = new Motorbike();
                m.LoadBinary(br);

                motorbikeDict[key] = m;
            }
            
            isLoaded = true;
        }

        //The initial motorbikes that will exist within the system (until removed)
        private static void AddInitialMotorbikes()
        {
            Motorbike b1 = new Motorbike("Harley Davidson", "RoadGlide", 2023, 25856, 200, "HD23LOW");
            motorbikeDict.Add(b1.GetNumberPlate()!, b1);

            Motorbike b2 = new Motorbike("BMW", "F900 GS", 2025, 1298, 180, "BM25SPD");
            motorbikeDict.Add(b2.GetNumberPlate()!, b2);

            Motorbike b3 = new Motorbike("BMW", "R1300 GS Adventure", 2024, 11092, 200, "SP24LOR");
            motorbikeDict.Add(b3.GetNumberPlate()!, b3);

            Motorbike b4 = new Motorbike("Honda", "RoadGlide", 2019, 28933, 200, "HN19DAR");
            motorbikeDict.Add(b4.GetNumberPlate()!, b4);
        }
    }

    //Using inheritance here to take each field from the Vehicle class and use it for the motorbikes
    public class Motorbike : Vehicle
    {
        public Motorbike() { }

        public Motorbike(string make, string model, int yearOfManufacture, int mileage, int pricePerDay, string numberPlate)
            : base(make, model, yearOfManufacture, mileage, pricePerDay, numberPlate)
        {
            //Didn't need to include override here and I
            //Don't need the category class as I didn't include it for the motorbikes (they're not as easy to categorise)
        }
    }
}