using VehicleInfo;
using CarInfo;
using VanInfo;
using MotorbikeInfo;
using System.Text.Json;

namespace VehicleInfo
{
    public static class VehicleManagement
    {

        public static void LoadCars()
        {
            CarData.LoadJsonData();
        }
        public static void LoadMotorbikes()
        {
            MotorbikeData.LoadJsonData();
        }
        public static void LoadVans()
        {
            VanData.LoadJsonData();
        }
        public static void addCar()
        {
            //Loading the cars from the JSON file. 
            LoadCars();

            Utilities.insertBreak();
            Console.WriteLine("Please complete the following fields for the CAR you wish to add");
            Utilities.insertBreak();
            Console.Write("MAKE: ");
            string carMake = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("MODEL: ");
            string carModel = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("YEAR OF MANUFACTURE: ");
            string stringCarYearOfManufacture = Console.ReadLine()!;
            int intCarYearOfManufacture = Convert.ToInt32(stringCarYearOfManufacture);
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringCarMileage = Console.ReadLine()!;
            int intCarMileage = Convert.ToInt32(stringCarMileage);
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string carCategory = Console.ReadLine()!.Trim().ToLower(); ;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay = Convert.ToInt32(stringPricePerDay);
            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string carPlate = Console.ReadLine()!;

            //Using this opportunity to showcase another way of working around potential errors
            //For example here, the logic would get unneccessarily long and complex if I used the same method as usual
            //Whereas, here cutting that out I can account for a change in case (uppercase or lowercase, the system ignores it)
            if (!(carCategory.Equals("Small", StringComparison.OrdinalIgnoreCase)
            || carCategory.Equals("Medium", StringComparison.OrdinalIgnoreCase)
                || carCategory.Equals("Large", StringComparison.OrdinalIgnoreCase)))
            {
                Utilities.invalidInput();
                Console.WriteLine("Please EXIT and RETRY.");
                return;
            }

            else
            {
                //Getting the details of the car from the user.
                Car newCar = new Car
                {
                    make = carMake,
                    model = carModel,
                    yearOfManufacture = intCarYearOfManufacture,
                    mileage = intCarMileage,
                    category = carCategory,
                    pricePerDay = intPricePerDay,
                    numberPlate = carPlate
                };
                //Adding the car to the dictionary.
                CarData.carDict.Add(newCar.numberPlate, newCar);

                //Saving the Cars to the JSON file.
                CarData.SaveToJson();
                Console.WriteLine("CAR ADDED");
            }
        }
        public static void addVan()
        {
            LoadVans();

            Utilities.insertBreak();
            Console.WriteLine("Please complete the following fields for the VAN you wish to add");
            Console.Write("MAKE: ");
            string vanMake = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("MODEL: ");
            string vanModel = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("YEAR OF MANUFACTURE: ");
            string stringVanYearOfManufacture = Console.ReadLine()!;
            int intVanYearOfManufacture = Convert.ToInt32(stringVanYearOfManufacture);
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringVanMileage = Console.ReadLine()!;
            int intVanMileage = Convert.ToInt32(stringVanMileage);
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string vanCategory = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay = Convert.ToInt32(stringPricePerDay);
            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string vanPlate = Console.ReadLine()!;

            //Using this opportunity to showcase another way of working around potential errors
            //For example here, the logic would get unneccessarily long and complex if I used the same method as usual
            //Whereas here, cutting that out I can account for a change in case (uppercase or lowercase, the system ignores it)
            if (!(vanCategory.Equals("Small", StringComparison.OrdinalIgnoreCase)
            || vanCategory.Equals("Medium", StringComparison.OrdinalIgnoreCase)
                || vanCategory.Equals("Large", StringComparison.OrdinalIgnoreCase)))
            {
                Utilities.invalidInput();
                Console.WriteLine("Please EXIT and RETRY.");
                return;
            }

            else
            {
                //Getting the details of the van from the user.
                Van newVan = new Van
                {
                    make = vanMake,
                    model = vanModel,
                    yearOfManufacture = intVanYearOfManufacture,
                    mileage = intVanMileage,
                    category = vanCategory,
                    pricePerDay = intPricePerDay,
                    numberPlate = vanPlate
                };
                //Adding the van to the dictionary.
                VanData.vanDict.Add(newVan.numberPlate, newVan);

                //Saving the Van to the JSON file.
                VanData.SaveToJson();

                Utilities.insertBreak();
                Console.WriteLine("VAN ADDED");
            }
        }
        public static void addMotorbike()
        {
            LoadMotorbikes();

            Utilities.insertBreak();
            Console.WriteLine("Please complete the following fields for the MOTORBIKE you wish to add");
            Console.Write("MAKE: ");
            string motorbikeMake = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("MODEL: ");
            string motorbikeModel = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("YEAR OF MANUFACTURE: ");
            string stringYearOfManufacture = Console.ReadLine()!;
            int intYearOfManufacture = Convert.ToInt32(stringYearOfManufacture);
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringMotorbikeMileage = Console.ReadLine()!;
            int intMotorbikeMileage = Convert.ToInt32(stringMotorbikeMileage);
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string motorbikeCategory = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay = Convert.ToInt32(stringPricePerDay);
            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string motorbikePlate = Console.ReadLine()!;

            //The motorbike does not have a category that it fits into.
            //Therefore, the category check logic is rendered useless here.
            //Which is why it has been taken out.

            //Getting the details of the van from the user.
            Motorbike newMotorbike = new Motorbike
            {
                make = motorbikeMake,
                model = motorbikeModel,
                yearOfManufacture = intYearOfManufacture,
                mileage = intMotorbikeMileage,
                pricePerDay = intPricePerDay,
                numberPlate = motorbikePlate
            };
            //Adding the van to the dictionary.
            MotorbikeData.motorbikeDict.Add(newMotorbike.numberPlate, newMotorbike);

            //Saving the Van to the JSON file.
            MotorbikeData.SaveToJson();

            Utilities.insertBreak();
            Console.WriteLine("MOTORBIKE ADDED");
        }
        public static void removeCar()
        {
            LoadCars();

            if (CarData.carDict.ContainsKey(userCarMakeSelection))
            {
                CarData.carDict.Remove(userCarMakeSelection);
            }
            else
            {
                var rentedCar = CarData.carDict.FirstOrDefault(Car =>
                Car.Value.make.Equals(userCarMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                Car.Value.model.Equals(userCarModelSelection, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(rentedCar.Key))
                {
                    CarData.carDict.Remove(rentedCar.Key);
                }
                else
                {
                    Console.WriteLine("Could not find the car wihtin the list");
                }
            }

            var json = JsonSerializer.Serialize(CarData.carDict, new JsonSerializerOptions { WriteIndented = true });
            CarData.SaveToJson();
        }
    }
}