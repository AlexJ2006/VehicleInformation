using VehicleInfo;
using CarInfo;
using VanInfo;
using MotorbikeInfo;
using System.Text.Json;
using System.Security.Cryptography;

namespace VehicleInfo
{
    public static class VehicleManagement
    {
        public static void guestMenu()
        {
            //Insert GUEST functions here
            Utilities.insertBreak();
            Console.Write("Please enter your NAME: ");
            string guestName = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.WriteLine($"Welcome, {guestName}!");
            Utilities.insertBreak();
            Console.WriteLine("Please choose from ONE of the following options:");
            Utilities.insertBreak();
            Console.Write("C for CAR, M for MOTORCYCLE, V for VAN: ");
            string vehicleType = Console.ReadLine()!;

            //Cars
            if (vehicleType == "C" || vehicleType == "c")
            {
                LoadCars();
                Utilities.insertBreak();
                Console.WriteLine("You have chosen CAR");
                Utilities.insertBreak();

                Console.WriteLine("Which category of CAR would you like to rent?");
                Utilities.insertBreak();
                Console.Write("The options are SMALL, MEDIUM or LARGE: ");
                string categoryChoice = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.WriteLine($"You have chosen {categoryChoice}");
                Utilities.insertBreak();

                Console.Write("What is your maximum Price Per Day?: ");
                string maxPriceString = Console.ReadLine()!;
                int maxPriceInt;

                try
                {
                    maxPriceInt = Convert.ToInt32(maxPriceString);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + maxPriceString + "'to a number");
                    return;
                }
                Console.WriteLine("The options meeting your criteria are: ");
                // TRYING TO GET THIS TO WORK TO PRESENT THE USER WITH MULTIPLE PIECES OF INFORMATION
                Utilities.insertBreak();
                //I HAVE REMOVED IENUMERABLE, WILL THIS STILL WORK?
                var carList =
                CarData.carDict
                .Where(car =>
                    car.Value.pricePerDay <= maxPriceInt &&
                    car.Value.category.Equals(categoryChoice, StringComparison.OrdinalIgnoreCase))
                .Select(car => new { car.Value.make, car.Value.model, car.Value.pricePerDay });

                foreach (var Car in carList)
                {
                    Console.WriteLine($"{Car.make} - {Car.model} - £{Car.pricePerDay}/day");
                    Utilities.insertBreak();
                }

                Console.WriteLine("Please fill out the following fields for the CAR you wish to RENT");
                Utilities.insertBreak();
                Console.Write("MAKE: ");
                string userCarMakeSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("MODEL: ");
                string userCarModelSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("How many days would you like to rent the CAR for?: ");
                string stringNumberOfDaysRental = Console.ReadLine()!;

                int numberOfDaysRental;

                try
                {
                    numberOfDaysRental = Convert.ToInt32(stringNumberOfDaysRental);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + maxPriceString + "'to a number");
                    return;
                }
                Utilities.insertBreak();

                Console.WriteLine($"You would like to rent the {userCarMakeSelection} {userCarModelSelection}");
                Utilities.insertBreak();
                Console.WriteLine($"For {numberOfDaysRental} days?");
                Console.Write("Press Y to CONTINUE: ");
                string continueWithRental = Console.ReadLine()!;
                Utilities.insertBreak();

                if (continueWithRental == "Y" || continueWithRental == "y")
                {
                    var userCarSelection = CarData.carDict.Values.FirstOrDefault(Car =>
                    Car.make.Equals(userCarMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                    Car.model.Equals(userCarModelSelection, StringComparison.OrdinalIgnoreCase));


                    if (userCarSelection != null)
                    {
                        int totalPrice = userCarSelection.pricePerDay * numberOfDaysRental;
                        Console.WriteLine($"Your total will be £{totalPrice}");

                        VehicleManagement.removeCar(userCarMakeSelection, userCarModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userCarMakeSelection} {userCarModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("CAR NOT FOUND.");
                    }
                }
                else if (continueWithRental == "N" || continueWithRental == "n")
                {
                    Console.WriteLine("Thank you.");
                    Console.WriteLine("The program will now TERMINATE.");
                    return;
                }
                else
                {
                    Utilities.invaliInputDuringRental();
                }

                // CAR REMOVAL FUNCTION
                }
            //Motorbikes
            else if (vehicleType == "M" || vehicleType == "m")
            {
                LoadMotorbikes();

                Utilities.insertBreak();
                Console.Write("What is your maximum Price Per Day?: ");
                string maxPriceString = Console.ReadLine()!;
                int maxPriceInt;

                try
                {
                    maxPriceInt = Convert.ToInt32(maxPriceString);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + maxPriceString + "'to a number");
                    return;
                }
               
                Utilities.insertBreak();
                Console.WriteLine("Your Options are: ");
                Utilities.insertBreak();

                var motorbikeList =
                    MotorbikeData.motorbikeDict
                        .Where(motorbike =>
                        (motorbike.Value.pricePerDay <= maxPriceInt))
                        .Select(motorbike => new { motorbike.Value.make, motorbike.Value.model, motorbike.Value.pricePerDay });
                foreach (var motorbike in motorbikeList)
                {
                    Console.WriteLine($"{motorbike.make} - {motorbike.model} - £{motorbike.pricePerDay}/day");
                    Utilities.insertBreak();
                }
                Console.WriteLine("Please fill out the following fields for the MOTORBIKE you wish to RENT");
                Utilities.insertBreak();
                Console.Write("MAKE: ");
                string userMotorbikeMakeSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("MODEL: ");
                string userMotorbikeModelSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("How many days would you like to rent the MOTORBIKE for?: ");
                string stringNumberOfDaysRental = Console.ReadLine()!;
                int numberOfDaysRental;

                try
                {
                    numberOfDaysRental = Convert.ToInt32(stringNumberOfDaysRental);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringNumberOfDaysRental + "'to a number");
                    return;
                }
                Utilities.insertBreak();

                Console.WriteLine($"You would like to rent the {userMotorbikeMakeSelection} {userMotorbikeModelSelection}");
                Utilities.insertBreak();
                Console.WriteLine($"For {numberOfDaysRental} days?");
                Console.Write("Press Y to CONTINUE: ");
                string continueWithRental = Console.ReadLine()!;
                Utilities.insertBreak();

                if (continueWithRental == "Y" || continueWithRental == "y")
                {
                    var userMotorbikeSelection = MotorbikeData.motorbikeDict.Values.FirstOrDefault(Motorbike =>
                    Motorbike.make.Equals(userMotorbikeMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                    Motorbike.model.Equals(userMotorbikeModelSelection, StringComparison.OrdinalIgnoreCase));

                    if (userMotorbikeSelection != null)
                    {
                        int totalPrice = userMotorbikeSelection.pricePerDay * numberOfDaysRental;
                        Console.WriteLine($"Your total will be £{totalPrice}");

                        VehicleManagement.removeMotorbike(userMotorbikeMakeSelection, userMotorbikeModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userMotorbikeMakeSelection} {userMotorbikeModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("MOTORBIKE NOT FOUND.");
                    }
                }
            }
            //Vans
            else if (vehicleType == "V" || vehicleType == "v")
            {
                LoadVans();

                Utilities.insertBreak();
                Console.WriteLine("Which category of VAN would you like to rent?");
                Utilities.insertBreak();
                Console.Write("The options are SMALL, MEDIUM or LARGE: ");
                string categoryChoice = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.WriteLine($"You have chosen {categoryChoice}");
                Utilities.insertBreak();

                Console.Write("What is your maximum Price Per Day?: ");
                string maxVanPriceString = Console.ReadLine()!;
                int maxVanPriceInt;

                try
                {
                    maxVanPriceInt = Convert.ToInt32(maxVanPriceString);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + maxVanPriceString + "'to a number");
                    return;
                }
                Utilities.insertBreak();
                Console.WriteLine("Your Options are: ");

                Utilities.insertBreak();

                var vanList =
                    VanData.vanDict
                        .Where(van =>
                        (van.Value.pricePerDay <= maxVanPriceInt))
                        .Select(van => new { van.Value.make, van.Value.model, van.Value.pricePerDay });

                foreach (var van in vanList)
                {
                    Console.WriteLine($"{van.make} - {van.model} - £{van.pricePerDay}/day");
                    Utilities.insertBreak();
                }
                Console.WriteLine("Please fill out the following fields for the VAN you wish to RENT");
                Utilities.insertBreak();
                Console.Write("MAKE: ");
                string userVanMakeSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("MODEL: ");
                string userVanModelSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("How many days would you like to rent the VAN for?: ");
                string stringNumberOfDaysVanRental = Console.ReadLine()!;
                int numberOfDaysVanRental;

                try
                {
                    numberOfDaysVanRental = Convert.ToInt32(stringNumberOfDaysVanRental);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringNumberOfDaysVanRental + "'to a number");
                    return;
                }
                Utilities.insertBreak();

                Console.WriteLine($"You would like to rent the {userVanMakeSelection} {userVanModelSelection}");
                Console.WriteLine($"For {numberOfDaysVanRental} days?");
                Utilities.insertBreak();
                Console.Write("Press Y to CONTINUE: ");
                string continueWithVanRental = Console.ReadLine()!;
                Utilities.insertBreak();

                if (continueWithVanRental == "Y" || continueWithVanRental == "y")
                {
                    var userVanSelection = VanData.vanDict.Values.FirstOrDefault(Van =>
                    Van.make.Equals(userVanMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                    Van.model.Equals(userVanModelSelection, StringComparison.OrdinalIgnoreCase));

                    if (userVanSelection != null)
                    {
                        int totalPrice = userVanSelection.pricePerDay * numberOfDaysVanRental;
                        Console.WriteLine($"Your total will be £{totalPrice}");

                        VehicleManagement.removeVan(userVanMakeSelection, userVanModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userVanMakeSelection} {userVanModelSelection} for {numberOfDaysVanRental} days, costing £{totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("VAN NOT FOUND");
                    }
                }
                //If the user has not inputted C, M or V...
                else
                {
                    Utilities.invalidInput();
                }
            }
        }

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
            
            int intCarYearOfManufacture;

                try
                {
                    intCarYearOfManufacture= Convert.ToInt32(stringCarYearOfManufacture);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringCarYearOfManufacture + "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringCarMileage = Console.ReadLine()!;
            
            int intCarMileage;

                try
                {
                    intCarMileage = Convert.ToInt32(stringCarMileage);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringCarMileage + "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string carCategory = Console.ReadLine()!.Trim().ToLower(); ;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay;

                try
                {
                    intPricePerDay = Convert.ToInt32(stringPricePerDay);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringPricePerDay + "'to a number");
                    return;
                }

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
            int intVanYearOfManufacture;
            try
                {
                    intVanYearOfManufacture = Convert.ToInt32(stringVanYearOfManufacture);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringVanYearOfManufacture + "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringVanMileage = Console.ReadLine()!;
            int intVanMileage;
            try
                {
                    intVanMileage = Convert.ToInt32(stringVanMileage);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringVanMileage + "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string vanCategory = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay;
            try
                {
                    intPricePerDay = Convert.ToInt32(stringPricePerDay);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringPricePerDay + "'to a number");
                    return;
                }
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
           int intYearOfManufacture;
            try
                {
                    intYearOfManufacture = Convert.ToInt32(stringYearOfManufacture);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringYearOfManufacture + "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringMotorbikeMileage = Console.ReadLine()!;
            int intMotorbikeMileage;
            try
                {
                    intMotorbikeMileage = Convert.ToInt32(stringMotorbikeMileage);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringMotorbikeMileage+ "'to a number");
                    return;
                }
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string motorbikeCategory = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay;
            try
                {
                    intPricePerDay = Convert.ToInt32(stringPricePerDay);
                }
                catch (FormatException)
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringPricePerDay + "'to a number");
                    return;
                }
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
        public static void removeCar(string userCarMakeSelection, string userCarModelSelection)
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
                    Utilities.errorRedWarning();
                    Console.WriteLine("Could not find the car wihtin the list");
                }
            }

            var json = JsonSerializer.Serialize(CarData.carDict, new JsonSerializerOptions { WriteIndented = true });
            CarData.SaveToJson();
        }
        public static void removeVan( string userVanMakeSelection, string userVanModelSelection)
        {
            LoadVans();

            if (VanData.vanDict.ContainsKey(userVanMakeSelection))
            {
                VanData.vanDict.Remove(userVanMakeSelection);
            }
            else
            {
                var rentedVan = VanData.vanDict.FirstOrDefault(Van =>
                Van.Value.make.Equals(userVanMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                Van.Value.model.Equals(userVanModelSelection, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(rentedVan.Key))
                {
                    VanData.vanDict.Remove(rentedVan.Key);
                }
                else
                {
                    Utilities.errorRedWarning();
                    Console.WriteLine("Could not find the van wihtin the list");
                }
            }

            var json = JsonSerializer.Serialize(VanData.vanDict, new JsonSerializerOptions { WriteIndented = true });
            VanData.SaveToJson();
        }
        public static void removeMotorbike(string userMotorbikeMakeSelection, string userMotorbikeModelSelection)
        {
            LoadMotorbikes();

            if (MotorbikeData.motorbikeDict.ContainsKey(userMotorbikeMakeSelection))
            {
                MotorbikeData.motorbikeDict.Remove(userMotorbikeMakeSelection);
            }
            else
            {
                var rentedMotorbike = MotorbikeData.motorbikeDict.FirstOrDefault(Motorbike =>
                Motorbike.Value.make.Equals(userMotorbikeMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                Motorbike.Value.model.Equals(userMotorbikeModelSelection, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(rentedMotorbike.Key))
                {
                    MotorbikeData.motorbikeDict.Remove(rentedMotorbike.Key);
                }
                else
                {
                    Utilities.errorRedWarning();
                    Console.WriteLine("Could not find the car wihtin the list");
                }
            }
            var json = JsonSerializer.Serialize(MotorbikeData.motorbikeDict, new JsonSerializerOptions { WriteIndented = true });
            MotorbikeData.SaveToJson();
        }
    }
}