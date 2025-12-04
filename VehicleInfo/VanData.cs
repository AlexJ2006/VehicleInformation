using System.IO;
using VehicleInfo;

namespace VanInfo
{
    public static class VanData
    {
        // Dictionary to store all the vans using their number plate as the key
        public static Dictionary<string, Van> vanDict = new Dictionary<string, Van>();
        private static readonly string filepath = "vans.bin";

        private static bool isLoaded = false;

        public static void SaveToBinary()
        {
            using FileStream fs = File.Open(filepath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            // Write how many vans exist in the dictionary
            bw.Write(vanDict.Count);

            // Loop over each van and save its data
            foreach (var pair in vanDict)
            {
                bw.Write(pair.Key);          // Write the dictionary key (number plate)
                pair.Value.SaveBinary(bw);   // Save the van object
            }
        }

        public static void LoadFromBinary(bool forceReload = false)
        {

            if(isLoaded && !forceReload)
            {
                return;
            }
            
            // Reset the dictionary before loading
            vanDict = new Dictionary<string, Van>();

            if(!File.Exists(filepath))
            {
                AddInitialVans();
                SaveToBinary();
                isLoaded = true;
                return;
            }

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            // Read the number of vans stored in the file
            int count = br.ReadInt32();

            // Loop to load each van
            for (int i = 0; i < count; i++)
            {
                string numberPlate = br.ReadString(); // Read the dictionary key

                Van v = new Van();     // Create a new Van object
                v.LoadBinary(br);      // Load its data from the binary file

                vanDict[numberPlate] = v; // Add the van to the dictionary
            }

            isLoaded = true;
        }

        // Adding in some initial vans for testing purposes
        private static void AddInitialVans()
        {
            Van v1 = new Van("Mercedes", "Sprinter", 2019, 125927, "Large", 200, "MD69SPR");
            vanDict.Add(v1.GetNumberPlate()!, v1);

            Van v2 = new Van("Volkswagen", "Caddy", 2023, 56929, "Small", 200, "VW23MDS");
            vanDict.Add(v2.GetNumberPlate()!, v2);

            Van v3 = new Van("Ford", "Transit", 2020, 84562, "Small", 180, "BM28JHS");
            vanDict.Add(v3.GetNumberPlate()!, v3);

            Van v4 = new Van("Renault", "Kangoo", 2023, 98233, "Small", 185, "JD82DSK");
            vanDict.Add(v4.GetNumberPlate()!, v4);
        }
    }

    // Creating a Van class here that inherits all of the properties from Vehicle.
    // On top of this, the Van class has its own new property of Category.
    public class Van : Vehicle
    {
        // Category is added to the class here.
        private string? category;

        // With its own getters and setters
        public string? GetCategory() => category;
        public void SetCategory(string cat) => category = cat;

        public Van() { }

        public Van(string make, string model, int year, int mileage, string category, int price, string plate)
            : base(make, model, year, mileage, price, plate)
        {
            this.category = category;
        }

        // Overriding SaveBinary to include the category field
        public override void SaveBinary(BinaryWriter bw)
        {
            base.SaveBinary(bw);      // Save all base class fields
            bw.Write(category ?? "");  // Save Van-specific field
        }

        // Overriding LoadBinary to include the category field
        public override void LoadBinary(BinaryReader br)
        {
            base.LoadBinary(br);      // Load all base class fields
            category = br.ReadString(); // Load Van-specific field
        }
    }
}