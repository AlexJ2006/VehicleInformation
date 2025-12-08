using VanInfo;
using MotorbikeInfo;

namespace VehicleInfo
{
    public static class VehicleManagement
    {
        //Creating the guest menu
        public static void guestMenu()
        {
            //Setting the date as today's date.
            DateTime rentalStartDate = DateTime.Today; 

            Utilities.insertBreak();
            Console.Write("Please enter your NAME: "); //Asking the user for their name
            string guestName = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.WriteLine($"Welcome, {guestName}!"); //Welcoming them, by name
            Utilities.insertBreak();
            Console.WriteLine("Which type of vehicle would you like to RENT?:");
            Utilities.insertBreak();
            Console.Write("C for CAR, M for MOTORCYCLE, V for VAN: "); //Showing them the options that they can choose from
            string vehicleType = Console.ReadLine()!;

            if (vehicleType.Equals("C", StringComparison.OrdinalIgnoreCase)) //If they have chosen Car
            {
                LoadCars(); //Load the cars from the binary file
                Utilities.insertBreak();
                Console.WriteLine("You have chosen CAR");
                Utilities.insertBreak();

                Console.WriteLine("Which category of CAR would you like to rent?"); //Asking the user which category of car they wish to rent
                Utilities.insertBreak();
                Console.Write("The options are SMALL, MEDIUM or LARGE: "); //Displaying the category options
                string categoryChoice = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.WriteLine($"You have chosen {categoryChoice}"); //Relaying their choice back to them, to ensure this is correct
                Utilities.insertBreak();

                Console.Write("What is your maximum Price Per Day?: "); //Asking htem what their maximum price per day for the car is
                string maxPriceString = Console.ReadLine()!; 
                int maxPriceInt;
                
                try
                {
                    maxPriceInt = Convert.ToInt32(maxPriceString); //Converting the string into an integer
                }
                catch (FormatException) //Catching a format exception
                {
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + maxPriceString + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer. //Warning the user that they string cannot be converted into an integer
                    return;
                }

                //If everything goes smoothly...
                Console.ForegroundColor = ConsoleColor.Green;
                Utilities.insertBreak();
                Console.WriteLine("The options meeting your criteria are: ");
                Console.ResetColor();
                Utilities.insertBreak();

                //Displaying the options to the user
                var carList = CarData.carDict
                    .Where(car =>
                        car.Value.GetPricePerDay() <= maxPriceInt && //Based on their desired PricePerDay 
                        string.Equals(car.Value.GetCategory(), categoryChoice, StringComparison.OrdinalIgnoreCase)) //And their category choice
                    .Select(car => new 
                    {
                        //Fetching the details of the applicable cars (from the binary file)
                        Make = car.Value.GetMake(),
                        Model = car.Value.GetModel(),
                        PricePerDay = car.Value.GetPricePerDay(),
                        NumberPlate = car.Value.GetNumberPlate()
                    });

                //Looping over all of the applicable cars and displaying them in the following format.
                foreach (var Car in carList)
                {
                    Console.WriteLine($"{Car.Make} - {Car.Model} - {Car.NumberPlate} - £{Car.PricePerDay}/day"); 
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
                Console.Write("NUMBER PLATE: ");
                string userNumberPlateSelection = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("How many days would you like to rent the CAR for?: ");
                string stringNumberOfDaysRental = Console.ReadLine()!;
                int numberOfDaysRental;

                //Same exception handling here as for the integer conversion above
                //But for the number of days rental instead
                try
                {
                    numberOfDaysRental = Convert.ToInt32(stringNumberOfDaysRental);
                    
                }
                catch (FormatException)
                {
                    //Warning the user that the string they have provided cannot be converted into an integer
                    Utilities.errorYellowWarning();
                    Console.Write("Cannot convert '" + stringNumberOfDaysRental + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                    return;
                }

                //Adding the chosen number of days onto the start date... giving the user the end date.
                DateTime rentalEndDate = rentalStartDate.AddDays(numberOfDaysRental);

                //Repeating the user's choices back to the user for confirmation that they are correct
                Utilities.insertBreak();
                Console.WriteLine($"You would like to rent the {userCarMakeSelection} {userCarModelSelection}");
                Utilities.insertBreak();
                Console.WriteLine($"For {numberOfDaysRental} days?");
                Utilities.insertBreak();
                Console.Write("Press Y to CONTINUE: ");
                string continueWithRental = Console.ReadLine()!;
                Utilities.insertBreak();

                //If the user selects to continue with the rental...
                if (continueWithRental.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    var userCarSelection = CarData.carDict.Values.FirstOrDefault(car =>
                    !string.IsNullOrEmpty(car.GetMake()) &&
                    !string.IsNullOrEmpty(car.GetModel()) &&
                    car.GetMake()!.Equals(userCarMakeSelection, StringComparison.OrdinalIgnoreCase) &&
                    car.GetModel()!.Equals(userCarModelSelection, StringComparison.OrdinalIgnoreCase));

                    if (userCarSelection != null) //If the car has been found
                    {
                        //Calculating the total price for the rental (price per day multipplied by the number of days the user wished to rent the car for)
                        int totalPrice = userCarSelection.GetPricePerDay() * numberOfDaysRental;
                        Console.WriteLine($"Your total will be £{totalPrice}"); //Displaying the total price to the user

                        removeCar(userCarMakeSelection, userCarModelSelection); //Removing the car from the list so someone else cannot also rent it (until it is re-added by a member of staff)
                        Utilities.insertBreak();
                        Console.WriteLine($"Thank you, you have rented the {userCarMakeSelection} {userCarModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");//The final summary of the rental is displayed to the user
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental START date {rentalStartDate: dd/MM/yy}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental END date {rentalEndDate: dd/MM/yy}");
                    }
                    else
                    {
                        //If the car cannot be found, an error message is presented to the user
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CAR NOT FOUND");
                        Console.ResetColor();
                    }
                }
                //If the user decides not to continue with the rental
                else if (continueWithRental.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you.");
                    Utilities.insertBreak();
                    Console.WriteLine("The program will now TERMINATE."); //The program ends
                    Utilities.insertBreak();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Car has NOT been rented.");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                else
                {
                    //If the user has inputted something incorrectly during the rental, the error message will be taken from Utiltiies and displayed to them
                    Utilities.invaliInputDuringRental();
                }
            }
            //If the vehicle that the user wishes to rent is a motorbike, the same logic repeats as for the car section.
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
                    Console.Write("Cannot convert '" + maxPriceString + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Utilities.insertBreak();
                Console.WriteLine("The options meeting your criteria are: ");
                Console.ResetColor();
                Utilities.insertBreak();

                var motorbikeList =
                    MotorbikeData.motorbikeDict
                        .Where(motorbike => motorbike.Value.GetPricePerDay() <= maxPriceInt)
                        .Select(motorbike => new
                        {
                            Make = motorbike.Value.GetMake(),
                            Model = motorbike.Value.GetModel(),
                            PricePerDay = motorbike.Value.GetPricePerDay(),
                            NumberPlate = motorbike.Value.GetNumberPlate()
                        });

                foreach (var motorbike in motorbikeList)
                {
                    Console.WriteLine($"{motorbike.Make} - {motorbike.Model} - {motorbike.NumberPlate} - £{motorbike.PricePerDay}/day");
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
                Console.Write("NUMBER PLATE: ");
                string userNumberPlateSelection = Console.ReadLine()!; 
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
                    Console.Write("Cannot convert '" + stringNumberOfDaysRental + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                    return;
                }

                DateTime rentalEndDate = rentalStartDate.AddDays(numberOfDaysRental);

                Utilities.insertBreak();
                Console.WriteLine($"You would like to rent the {userMotorbikeMakeSelection} {userMotorbikeModelSelection}");
                Utilities.insertBreak();
                Console.WriteLine($"For {numberOfDaysRental} days?");
                Utilities.insertBreak();
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

                    Utilities.insertBreak();
                    removeMotorbike(userMotorbikeMakeSelection, userMotorbikeModelSelection);
                    Console.WriteLine($"Thank you, you have rented the {userMotorbikeMakeSelection} {userMotorbikeModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                    Utilities.insertBreak();
                    Console.WriteLine($"Rental START date {rentalStartDate: dd/MM/yy}");
                    Utilities.insertBreak();
                    Console.WriteLine($"Rental END date {rentalEndDate: dd/MM/yy}");
                }
                else
                {
                    //If the car cannot be found, an error message is presented to the user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MOTORBIKE NOT FOUND");
                    Console.ResetColor();
                }
                }
                //If the user decides not to continue with the rental
                else if (continueWithRental.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you.");
                    Utilities.insertBreak();
                    Console.WriteLine("The program will now TERMINATE."); //The program ends
                    Utilities.insertBreak();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Motorbike has NOT been rented.");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                else
                {
                    //If the user has inputted something incorrectly during the rental, the error message will be taken from Utiltiies and displayed to them
                    Utilities.invaliInputDuringRental();
                }
            }
            //Finally, for the vans the same logic repeats again
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
                    Console.Write("Cannot convert '" + maxVanPriceString + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Utilities.insertBreak();
                Console.WriteLine("The options meeting your criteria are: ");
                Console.ResetColor();
                Utilities.insertBreak();

                var vanList = VanData.vanDict
                    .Where(van =>
                        van.Value.GetPricePerDay() <= maxVanPriceInt &&
                        string.Equals(van.Value.GetCategory(), categoryChoice, StringComparison.OrdinalIgnoreCase))
                    .Select(van => new 
                    {
                        Make = van.Value.GetMake(),
                        Model = van.Value.GetModel(),
                        PricePerDay = van.Value.GetPricePerDay(),
                        NumberPlate = van.Value.GetNumberPlate()
                    });

                foreach (var van in vanList)
                {
                    Console.WriteLine($"{van.Make} - {van.Model} - {van.NumberPlate} - £{van.PricePerDay}/day");
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
                Console.Write("NUMBER PLATE: ");
                string userNumberPlateSelection = Console.ReadLine()!; 
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
                    Console.Write("Cannot convert '" + stringNumberOfDaysVanRental + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                    return;
                }

                DateTime rentalEndDate = rentalStartDate.AddDays(numberOfDaysVanRental);

                Utilities.insertBreak();
                Console.WriteLine($"You would like to rent the {userVanMakeSelection} {userVanModelSelection}");
                Utilities.insertBreak();
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

                        Utilities.insertBreak();
                        removeVan(userVanMakeSelection, userVanModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userVanMakeSelection} {userVanModelSelection} for {numberOfDaysVanRental} days, costing £{totalPrice}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental START date {rentalStartDate: dd/MM/yy}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental END date {rentalEndDate: dd/MM/yy}");
                    }
                    else
                    {
                        //If the car cannot be found, an error message is presented to the user
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("MOTORBIKE NOT FOUND");
                        Console.ResetColor();
                    }
                }
                //If the user decides not to continue with the rental
                else if (continueWithVanRental.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thank you.");
                    Utilities.insertBreak();
                    Console.WriteLine("The program will now TERMINATE."); //The program ends
                    Utilities.insertBreak();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Van has NOT been rented.");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                else
                {
                    //If the user has inputted something incorrectly during the rental, the error message will be taken from Utiltiies and displayed to them
                    Utilities.invaliInputDuringRental();
                }
            }
        }
        //The function for loading the cars from the binary file (used in various places)
        public static void LoadCars()
        {
            CarData.LoadFromBinary();
        }
        //The function for loading the motorbikes from the binary file (used in various places)
        public static void LoadMotorbikes()
        {
            MotorbikeData.LoadFromBinary();
        }
        //The function for loading the vans from the binary file (used in various places)
        public static void LoadVans()
        {
            VanData.LoadFromBinary();
        }



















        //The function that allows the staff members to add cars 
        public static void addCar()
        {
            LoadCars(); //Loading the cars in from the binary file

            //Getting the details of the car from the user
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

            //Exception handling again here for the conversion of the year of manufacture
            try
            {
                intCarYearOfManufacture = Convert.ToInt32(stringCarYearOfManufacture);
            }
            catch (FormatException) //Handling a format exception
            {
                Utilities.errorYellowWarning();
                Console.Write("Cannot convert '" + stringCarYearOfManufacture + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                return;
            }

            Utilities.insertBreak();
            Console.Write("MILEAGE: ");
            string stringCarMileage = Console.ReadLine()!;
            int intCarMileage;

            //Repeating for the mileage of the car
            try
            {
                intCarMileage = Convert.ToInt32(stringCarMileage);
            }
            catch (FormatException) //Format exception handling again
            {
                Utilities.errorYellowWarning();
                Console.Write("Cannot convert '" + stringCarMileage + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                return;
            }

            //Getting which category the car belongs to
            Utilities.insertBreak();
            Console.Write("CATEGORY: ");
            string carCategory = Console.ReadLine()!.Trim();
            Utilities.insertBreak();
            Console.Write("PRICE PER DAY: ");
            string stringPricePerDay = Console.ReadLine()!;
            int intPricePerDay;

            //Same exception handling again for the price per day
            try
            {
                intPricePerDay = Convert.ToInt32(stringPricePerDay);
            }
            catch (FormatException)
            {
                Utilities.errorYellowWarning();
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
                return;
            }

            //Getting the number plate from the user
            Utilities.insertBreak();
            Console.Write("NUMBER PLATE: ");
            string carPlate = Console.ReadLine()!;

            //Error handling, if the category doesn't equal small, medium or large...
            if (!(carCategory.Equals("small", StringComparison.OrdinalIgnoreCase)
                || carCategory.Equals("medium", StringComparison.OrdinalIgnoreCase)
                || carCategory.Equals("large", StringComparison.OrdinalIgnoreCase)))
            {
                //The user will be told that their input is invalid
                Utilities.invalidInput();
                Console.WriteLine("Please EXIT and RETRY.");
                Environment.Exit(0);
            }

            //If the number plate can already be found within the dictionary
            if (CarData.carDict.ContainsKey(carPlate))
            {
                //The error message is provided to the user
                Utilities.errorYellowWarning();
                Console.WriteLine("A car with this plate already exists.");
                return;
            }

            //Creating a new instance of a car
            Car newCar = new Car(); 
            newCar.SetMake(carMake);
            newCar.SetModel(carModel);
            newCar.SetYearOfManufacture(intCarYearOfManufacture);
            newCar.SetMileage(intCarMileage);
            newCar.SetCategory(carCategory);
            newCar.SetPricePerDay(intPricePerDay);
            newCar.SetNumberPlate(carPlate);

            //Adding all of the fields above to the car dictionary        
            CarData.carDict.Add(newCar.GetNumberPlate()!, newCar);
            CarData.SaveToBinary();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CAR ADDED"); //Providing the user with a message detailing that the car has been added
            Console.ResetColor();
        }
































        //Repeating the same logic as above but for the vans
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
                Console.Write("Cannot convert '" + stringVanYearOfManufacture + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
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
                Console.Write("Cannot convert '" + stringVanMileage + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
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
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
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
                Environment.Exit(0);
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
            newVan.SetYearOfManufacture(intVanYearOfManufacture);
            newVan.SetMileage(intVanMileage);
            newVan.SetCategory(vanCategory);
            newVan.SetPricePerDay(intPricePerDay);
            newVan.SetNumberPlate(vanPlate);

            VanData.vanDict.Add(newVan.GetNumberPlate()!, newVan);
            VanData.SaveToBinary();
            Utilities.insertBreak();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("VAN ADDED");
            Console.ResetColor();
        }

        //Repeating yet again the same logic but for motorbikes
        public static void addMotorbike()
        {
            LoadMotorbikes();

            Utilities.insertBreak();
            Console.WriteLine("Please complete the following fields for the MOTORBIKE you wish to add");
            Utilities.insertBreak();

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
                Console.Write("Cannot convert '" + stringYearOfManufacture + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer. //Warning the user that the string they have entered cannot be converted to an integer.
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
                Console.Write("Cannot convert '" + stringMotorbikeMileage + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
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
                Console.Write("Cannot convert '" + stringPricePerDay + "' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
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
            newMotorbike.SetYearOfManufacture(intYearOfManufacture);
            newMotorbike.SetMileage(intMotorbikeMileage);
            newMotorbike.SetPricePerDay(intPricePerDay);
            newMotorbike.SetNumberPlate(motorbikePlate);

            MotorbikeData.motorbikeDict.Add(newMotorbike.GetNumberPlate()!, newMotorbike);
            MotorbikeData.SaveToBinary();
            
            Utilities.insertBreak();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MOTORBIKE ADDED");
            Console.ResetColor();
        }
        
        //The function that allows users to remove cars from the system
        public static void removeCar(string make, string model) //Taking the make and model as parameters
        {
            LoadCars(); //First, loading the cars in from the binary file

            var car = CarData.carDict.FirstOrDefault(c =>
                !string.IsNullOrEmpty(c.Value.GetMake()) &&
                !string.IsNullOrEmpty(c.Value.GetModel()) &&
                c.Value.GetMake()!.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                c.Value.GetModel()!.Equals(model, StringComparison.OrdinalIgnoreCase));
            
            //If the key isn't null
            if (car.Key != null)
            {
                CarData.carDict.Remove(car.Key); //Remove the car by the key
                CarData.SaveToBinary(); //Then, save the binary file to include the changes
            }
            else
            {
                //If the car can't be found, providing a warning for the user.
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the car within the list");
            }
        }

        //Same logic here as for the car removal
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
                VanData.SaveToBinary();
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the van within the list");
            }
        }
        
        //Same logic here as for the car removal
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
                MotorbikeData.SaveToBinary();
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the motorbike within the list");
            }
        }
    }
}