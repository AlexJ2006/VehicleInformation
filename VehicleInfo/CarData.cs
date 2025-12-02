using System.IO;

namespace VehicleInfo
{
    public static class CarData
    {
        // Dictionary to store all the cars using their number plate as the key
        public static Dictionary<string, Car> carDict = new Dictionary<string, Car>();
        private static readonly string filepath = "cars.bin";

        static CarData()
        {
            // If the binary file exists, load data from it
            if (File.Exists(filepath))
            {
                LoadFromBinary();
            }
            else
            {
                // Otherwise, add initial cars and save to binary
                AddInitialCars();
                SaveToBinary();
            }
        }

        public static void SaveToBinary()
        {
            // Using "using" statements ensures files are closed properly
            using FileStream fs = File.Open(filepath, FileMode.Create);
            using BinaryWriter bw = new BinaryWriter(fs);

            // Write how many cars exist in the dictionary
            bw.Write(carDict.Count);

            // Loop over each car and save its data
            foreach (var pair in carDict)
            {
                bw.Write(pair.Key);          // Write the dictionary key (number plate)
                pair.Value.SaveBinary(bw);   // Save the car object
            }
        }

        public static void LoadFromBinary()
        {
            // Reset the dictionary before loading
            carDict = new Dictionary<string, Car>();

            using FileStream fs = File.Open(filepath, FileMode.Open);
            using BinaryReader br = new BinaryReader(fs);

            // Read the number of cars stored in the file
            int count = br.ReadInt32();

            // Loop to load each car
            for (int i = 0; i < count; i++)
            {
                string numberPlate = br.ReadString(); // Read the dictionary key

                Car c = new Car();   // Create a new Car object
                c.LoadBinary(br);    // Load its data from the binary file

                carDict[numberPlate] = c; // Add the car to the dictionary
            }
        }

        // Adding in some initial cars for testing purposes (going to keep these here)
        // These WOULD be removed at a later date if the system was bought by someone else
        private static void AddInitialCars()
        {
            Car c1 = new Car("Ford", "Focus", 2019, 45000, "Small", 50, "FD19FCS");
            carDict.Add(c1.GetNumberPlate()!, c1);

            Car c2 = new Car("Volkswagen", "Golf", 2021, 30000, "Medium", 70, "VW21GLF");
            carDict.Add(c2.GetNumberPlate()!, c2);

            Car c3 = new Car("BMW", "3 Series", 2020, 20000, "Large", 100, "BM20SER");
            carDict.Add(c3.GetNumberPlate()!, c3);
        }
    }
    // Creating a Car class here that inherits all of the properties from Vehicle.
    // On top of this, the Car class has its own new property of Category.
    public class Car : Vehicle
    {
        // Category is added to the class here.
        private string? category;

        // With its own getters and setters
        public string? GetCategory() => category;
        public void SetCategory(string category) => this.category = category;

        // Detailing everything that is being inherited from the base class.
        public Car(string make, string model, int yearOfManufacture, int mileage,
                   string category, int pricePerDay, string numberPlate)
            : base(make, model, yearOfManufacture, mileage, pricePerDay, numberPlate)
        {
            // Specifying that category in this instance is the category from this file.
            this.category = category;
        }

        public Car() { }

        // Overriding SaveBinary to include the category field
        public override void SaveBinary(BinaryWriter bw)
        {
            base.SaveBinary(bw);      // Save all base class fields
            bw.Write(category ?? "");  // Save Car-specific field
        }

        // Overriding LoadBinary to include the category field
        public override void LoadBinary(BinaryReader br)
        {
            base.LoadBinary(br);      // Load all base class fields
            category = br.ReadString(); // Load Car-specific field
        }
    }
}