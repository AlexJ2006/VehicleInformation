using VanInfo;
using MotorbikeInfo;
using System.Drawing;

namespace VehicleInfo
{
    public static class CustomerMenuFunctions
    {
        //Creating the customer menu
        public static void CustomerMenu()
        {
            //Setting the current data and time for the start of the rental.
            DateTime customerRentalStartDate = DateTime.Today;

            Utilities.insertBreak();
            Console.WriteLine("Which type of vehicle would you like to RENT?:");
            Utilities.insertBreak();
            Console.Write("C for CAR, M for MOTORCYCLE, V for VAN: "); //Showing them the options that they can choose from
            string vehicleType = Console.ReadLine()!;

            if (vehicleType.Equals("C", StringComparison.OrdinalIgnoreCase)) //If they have chosen Car
            {
                VehicleManagement.LoadCars(); //Load the cars from the binary file
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

                //Adding the chosen number of days onto the start date... giving the customer the end date.
                DateTime customerRentalEndDate = customerRentalStartDate.AddDays(numberOfDaysRental);

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

                        Utilities.insertBreak();
                        VehicleManagement.removeCar(userCarMakeSelection, userCarModelSelection); //Removing the car from the list so someone else cannot also rent it (until it is re-added by a member of staff)
                        Utilities.insertBreak();
                        Console.WriteLine($"Thank you, you have rented the {userCarMakeSelection} {userCarModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}"); //The final summary of the rental is displayed to the user
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental START date {customerRentalStartDate: dd/MM/yy}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental END date {customerRentalEndDate: dd/MM/yy}");
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
                VehicleManagement.LoadMotorbikes();

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
                Utilities.insertBreak();
                string userMotorbikeModelSelection = Console.ReadLine()!;
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

                DateTime customerRentalEndDate = customerRentalStartDate.AddDays(numberOfDaysRental);

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
                    VehicleManagement.removeMotorbike(userMotorbikeMakeSelection, userMotorbikeModelSelection);
                    Console.WriteLine($"Thank you, you have rented the {userMotorbikeMakeSelection} {userMotorbikeModelSelection} for {numberOfDaysRental} days, costing £{totalPrice}");
                    Utilities.insertBreak();
                    Console.WriteLine($"Rental START date {customerRentalStartDate: dd/MM/yy}");
                    Utilities.insertBreak();
                    Console.WriteLine($"Rental END date {customerRentalEndDate: dd/MM/yy}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MOTORBIKE NOT FOUND");
                    Console.ResetColor();
                }
                }
                //If the user decides not to continue with the rental...
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
                    Utilities.invaliInputDuringRental();
                }
            }

            //Finally, for the vans the same logic repeats again
            else if (vehicleType == "V" || vehicleType == "v")
            {
                VehicleManagement.LoadVans();

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

                DateTime customerRentalEndDate = customerRentalStartDate.AddDays(numberOfDaysVanRental);

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
                        VehicleManagement.removeVan(userVanMakeSelection, userVanModelSelection);
                        Console.WriteLine($"Thank you, you have rented the {userVanMakeSelection} {userVanModelSelection} for {numberOfDaysVanRental} days, costing £{totalPrice}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental START date {customerRentalStartDate: dd/MM/yy}");
                        Utilities.insertBreak();
                        Console.WriteLine($"Rental END date {customerRentalEndDate: dd/MM/yy}");
                    }
                
                    else
                    {
                        //If the car cannot be found, an error message is presented to the user
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("MOTORBIKE NOT FOUND");
                        Console.ResetColor();
                    }
                }
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
    }
}
