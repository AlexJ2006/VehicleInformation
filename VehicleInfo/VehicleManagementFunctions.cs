using VanInfo;
using MotorbikeInfo;

namespace VehicleInfo
{
    public static class VehicleManagement
    {
        public static void guestMenu()
        {
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
                    Console.Write("Cannot convert '" + maxPriceString + "' to a number");
                    return;
                }

                Utilities.insertBreak();
                Console.WriteLine("The options meeting your criteria are: ");
                Utilities.insertBreak();

                var carList = CarData.carDict
                    .Where(car =>
                        car.Value.GetPricePerDay() <= maxPriceInt &&
                        string.Equals(car.Value.GetCategory(), categoryChoice, StringComparison.OrdinalIgnoreCase))
                    .Select(car => new 
                    {
                        Make = car.Value.GetMake(),
                        Model = car.Value.GetModel(),
                        PricePerDay = car.Value.GetPricePerDay()
                    });

                foreach (var Car in carList)
                {
                    Console.WriteLine($"{Car.Make} - {Car.Model} - £{Car.PricePerDay}/day");
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
                    Console.Write("Cannot convert '" + stringNumberOfDaysRental + "' to a number");
                    return;
                }

                Utilities.insertBreak();
                Console.WriteLine($"You would like to rent the {userCarMakeSelection} {userCarModelSelection}");
                Utilities.insertBreak();
                Console.WriteLine($"For {numberOfDaysRental} days?");
                Console.Write("Press Y to CONTINUE: ");
                string continueWithRental = Console.ReadLine()!;
                Utilities.insertBreak();

                if (continueWithRental.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    var userCarSelection = CarData.carDict.Values.FirstOrDefault(car =>
                    !string.IsNullOrEmpty(car.GetMake()) &&
                    !string.IsNullOrEmpty(car.GetModel()) &&
                    car.GetMake()!.Equals(userCarMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                    car.GetModel()!.Equals(userCarModelSelection, StringComparison.OrdinalIgnoreCase));

                    if (userCarSelection != null)
                    {
                        int totalPrice = userCarSelection.GetPricePerDay() * numberOfDaysRental;
                        Console.WriteLine($"Your total will be £{totalPrice}");

                        removeCar(userCarMakeSelection, userCarModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userCarMakeSelection} {userCarModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("CAR NOT FOUND.");
                    }
                }
                else if (continueWithRental.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you.");
                    Console.WriteLine("The program will now TERMINATE.");
                    return;
                }
                else
                {
                    Utilities.invaliInputDuringRental();
                }
            }


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
                    Console.Write("Cannot convert '" + maxPriceString + "' to a number");
                    return;
                }

                Utilities.insertBreak();
                Console.WriteLine("Your Options are: ");
                Utilities.insertBreak();

                var motorbikeList =
                    MotorbikeData.motorbikeDict
                        .Where(motorbike => motorbike.Value.GetPricePerDay() <= maxPriceInt)
                        .Select(motorbike => new
                        {
                            Make = motorbike.Value.GetMake(),
                            Model = motorbike.Value.GetModel(),
                            PricePerDay = motorbike.Value.GetPricePerDay()
                        });

                foreach (var motorbike in motorbikeList)
                {
                    Console.WriteLine($"{motorbike.Make} - {motorbike.Model} - £{motorbike.PricePerDay}/day");
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
                    Console.Write("Cannot convert '" + stringNumberOfDaysRental + "' to a number");
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
                   var userMotorbikeSelection = MotorbikeData.motorbikeDict.Values.FirstOrDefault(motorbike =>
                !string.IsNullOrEmpty(motorbike.GetMake()) &&
                !string.IsNullOrEmpty(motorbike.GetModel()) &&
                motorbike.GetMake()!.Equals(userMotorbikeMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                motorbike.GetModel()!.Equals(userMotorbikeModelSelection, StringComparison.OrdinalIgnoreCase));

                if (userMotorbikeSelection != null)
                {
                    int totalPrice = userMotorbikeSelection.GetPricePerDay() * numberOfDaysRental;
                    Console.WriteLine($"Your total will be £{totalPrice}");

                    removeMotorbike(userMotorbikeMakeSelection, userMotorbikeModelSelection);
                    Console.WriteLine($"Thank you, you have rented the {userMotorbikeMakeSelection} {userMotorbikeModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                }
                else
                {
                    Console.WriteLine("MOTORBIKE NOT FOUND.");
                }
                }
            }

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
                    Console.Write("Cannot convert '" + maxVanPriceString + "' to a number");
                    return;
                }

                Utilities.insertBreak();
                Console.WriteLine("Your Options are: ");
                Utilities.insertBreak();

                var vanList = VanData.vanDict
                    .Where(van =>
                        van.Value.GetPricePerDay() <= maxVanPriceInt &&
                        string.Equals(van.Value.GetCategory(), categoryChoice, StringComparison.OrdinalIgnoreCase))
                    .Select(van => new 
                    {
                        Make = van.Value.GetMake(),
                        Model = van.Value.GetModel(),
                        PricePerDay = van.Value.GetPricePerDay()
                    });

                foreach (var van in vanList)
                {
                    Console.WriteLine($"{van.Make} - {van.Model} - £{van.PricePerDay}/day");
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
                    Console.Write("Cannot convert '" + stringNumberOfDaysVanRental + "' to a number");
                    return;
                }

                Utilities.insertBreak();
                Console.WriteLine($"You would like to rent the {userVanMakeSelection} {userVanModelSelection}");
                Console.WriteLine($"For {numberOfDaysVanRental} days?");
                Utilities.insertBreak();
                Console.Write("Press Y to CONTINUE: ");
                string continueWithVanRental = Console.ReadLine()!;
                Utilities.insertBreak();

                if (continueWithVanRental.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    var userVanSelection = VanData.vanDict.Values.FirstOrDefault(v =>
                        !string.IsNullOrEmpty(v.GetMake()) &&
                        !string.IsNullOrEmpty(v.GetModel()) &&
                        v.GetMake()!.Equals(userVanMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                        v.GetModel()!.Equals(userVanModelSelection, StringComparison.OrdinalIgnoreCase));

                    if (userVanSelection != null)
                    {
                        int totalPrice = userVanSelection.GetPricePerDay() * numberOfDaysVanRental;
                        Console.WriteLine($"Your total will be £{totalPrice}");

                        removeVan(userVanMakeSelection, userVanModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userVanMakeSelection} {userVanModelSelection} for {numberOfDaysVanRental} days, costing £{totalPrice}");
                    }
                    else
                    {
                        Console.WriteLine("VAN NOT FOUND");
                    }
                }
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
                intCarYearOfManufacture = Convert.ToInt32(stringCarYearOfManufacture);
            }
            catch (FormatException)
            {
                Utilities.errorYellowWarning();
                Console.Write("Cannot convert '" + stringCarYearOfManufacture + "' to a number");
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
                Console.Write("Cannot convert '" + stringCarMileage + "' to a number");
                return;
            }

            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string carCategory = Console.ReadLine()!.Trim();
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
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number");
                return;
            }

            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string carPlate = Console.ReadLine()!;

            if (!(carCategory.Equals("small", StringComparison.OrdinalIgnoreCase)
                || carCategory.Equals("medium", StringComparison.OrdinalIgnoreCase)
                || carCategory.Equals("large", StringComparison.OrdinalIgnoreCase)))
            {
                Utilities.invalidInput();
                Console.WriteLine("Please EXIT and RETRY.");
                return;
            }

            if (CarData.carDict.ContainsKey(carPlate))
            {
                Utilities.errorYellowWarning();
                Console.WriteLine("A car with this plate already exists.");
                return;
            }

            Car newCar = new Car();
            newCar.SetMake(carMake);
            newCar.SetModel(carModel);
            newCar.SetYear(intCarYearOfManufacture);
            newCar.SetMileage(intCarMileage);
            newCar.SetCategory(carCategory);
            newCar.SetPricePerDay(intPricePerDay);
            newCar.SetNumberPlate(carPlate);

            CarData.carDict.Add(newCar.GetNumberPlate()!, newCar);
            CarData.SaveToJson();
            Console.WriteLine("CAR ADDED");
        }


        public static void addVan()
        {
            LoadVans();

            Utilities.insertBreak();
            Console.WriteLine("Please complete the following fields for the VAN you wish to add");
            Utilities.insertBreak();
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
                Console.Write("Cannot convert '" + stringVanYearOfManufacture + "' to a number");
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
                Console.Write("Cannot convert '" + stringVanMileage + "' to a number");
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
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number");
                return;
            }

            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string vanPlate = Console.ReadLine()!;

            if (!(vanCategory.Equals("Small", StringComparison.OrdinalIgnoreCase)
                || vanCategory.Equals("Medium", StringComparison.OrdinalIgnoreCase)
                || vanCategory.Equals("Large", StringComparison.OrdinalIgnoreCase)))
            {
                Utilities.invalidInput();
                Console.WriteLine("Please EXIT and RETRY.");
                return;
            }

            if (VanData.vanDict.ContainsKey(vanPlate))
            {
                Utilities.errorYellowWarning();
                Console.WriteLine("A van with this plate already exists.");
                return;
            }

            Van newVan = new Van();
            newVan.SetMake(vanMake);
            newVan.SetModel(vanModel);
            newVan.SetYear(intVanYearOfManufacture);
            newVan.SetMileage(intVanMileage);
            newVan.SetCategory(vanCategory);
            newVan.SetPricePerDay(intPricePerDay);
            newVan.SetNumberPlate(vanPlate);

            VanData.vanDict.Add(newVan.GetNumberPlate()!, newVan);
            VanData.SaveToJson();
            Utilities.insertBreak();
            Console.WriteLine("VAN ADDED");
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
                Console.Write("Cannot convert '" + stringYearOfManufacture + "' to a number");
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
                Console.Write("Cannot convert '" + stringMotorbikeMileage + "' to a number");
                return;
            }

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
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number");
                return;
            }

            Utilities.insertBreak();
            Console.Write("PLATE: ");
            string motorbikePlate = Console.ReadLine()!;

            if (MotorbikeData.motorbikeDict.ContainsKey(motorbikePlate))
            {
                Utilities.errorYellowWarning();
                Console.WriteLine("A motorbike with this plate already exists.");
                return;
            }

            Motorbike newMotorbike = new Motorbike();
            newMotorbike.SetMake(motorbikeMake);
            newMotorbike.SetModel(motorbikeModel);
            newMotorbike.SetYear(intYearOfManufacture);
            newMotorbike.SetMileage(intMotorbikeMileage);
            newMotorbike.SetPricePerDay(intPricePerDay);
            newMotorbike.SetNumberPlate(motorbikePlate);

            MotorbikeData.motorbikeDict.Add(newMotorbike.GetNumberPlate()!, newMotorbike);
            MotorbikeData.SaveToJson();

            Utilities.insertBreak();
            Console.WriteLine("MOTORBIKE ADDED");
        }

        public static void removeCar(string make, string model)
        {
            LoadCars();

            var car = CarData.carDict.FirstOrDefault(c =>
                !string.IsNullOrEmpty(c.Value.GetMake()) &&
                !string.IsNullOrEmpty(c.Value.GetModel()) &&
                c.Value.GetMake()!.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                c.Value.GetModel()!.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (car.Key != null)
            {
                CarData.carDict.Remove(car.Key);
                CarData.SaveToJson();
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the car within the list");
            }

        }

        public static void removeVan(string make, string model)
        {
            LoadVans();

            var van = VanData.vanDict.FirstOrDefault(v =>
                !string.IsNullOrEmpty(v.Value.GetMake()) &&
                !string.IsNullOrEmpty(v.Value.GetModel()) &&
                v.Value.GetMake()!.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                v.Value.GetModel()!.Equals(model, StringComparison.OrdinalIgnoreCase)
            );

            if (!string.IsNullOrEmpty(van.Key))
            {
                VanData.vanDict.Remove(van.Key);
                VanData.SaveToJson();
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the van within the list");
            }
        }

        public static void removeMotorbike(string make, string model)
        {
            LoadMotorbikes();

            var motorbike = MotorbikeData.motorbikeDict
                .FirstOrDefault(m =>
                    !string.IsNullOrEmpty(m.Value.GetMake()) &&
                    !string.IsNullOrEmpty(m.Value.GetModel()) &&
                    m.Value.GetMake()!.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                    m.Value.GetModel()!.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(motorbike.Key))
            {
                MotorbikeData.motorbikeDict.Remove(motorbike.Key);
                MotorbikeData.SaveToJson();
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the motorbike within the list");
            }
        }
    }
}


