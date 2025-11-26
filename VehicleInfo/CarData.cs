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


//INITIAL FORMATTING FOR THE CAR ITEMS
//Taken directly from program.cs during implementation

// //First Car (large)
// Car c1 = new Car();
// c1.make = "Ford";
// c1.model = "Galaxy";
// c1.yearOfManufacture = 2022;
// c1.mileage = 60897;
// c1.category = "Large";
// c1.pricePerDay = 150;
// c1.numberPlate = "MD62JKD";
// carDict.Add(c1.numberPlate, c1);
//Second Car (small)
// Car c2 = new Car();
// c2.make = "Dacia";
// c2.model = "Sandero";
// c2.yearOfManufacture = 2021;
// c2.mileage = 75061;
// c2.category = "Small";
// c2.pricePerDay = 80;
// c2.numberPlate = "DL21OLP";
// carDict.Add(c2.numberPlate, c2);
// //Third Car (Medium)
// Car c3 = new Car();
// c3.make = "Nissan";
// c3.model = "Quashqai";
// c3.yearOfManufacture = 2020;
// c3.mileage = 50982;
// c3.category = "Medium";
// c3.pricePerDay = 120;
// c3.numberPlate = "NM60LDS";
// carDict.Add(c3.numberPlate, c3);
//Fourth Car (small)
// Car c4 = new Car();
// c4.make = "Smart";
// c4.model = "ForFour";
// c4.yearOfManufacture = 2015;
// c4.mileage = 74982;
// c4.category = "Small";
// c4.pricePerDay = 85;
// c4.numberPlate = "WF15HGG";
// carDict.Add(c4.numberPlate, c4);
//Fifth Car (small)
// Car c5 = new Car();
// c5.make = "Toyota";
// c5.model = "Aygo";
// c5.yearOfManufacture = 2024;
// c5.mileage = 13521;
// c5.category = "Small";
// c5.pricePerDay = 100;
// c5.numberPlate = "MC24NEW";
// carDict.Add(c5.numberPlate, c5);
// //ADD MORE CARS HERE