// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
//Allowing program.cs to access my dictionary (info) files.
using CarInfo;
using MotorbikeInfo;
using VanInfo;
using storeList;
using System.Reflection;

//Showing the user the version as per the "Version" tag within the VehicleInfo.csproj file.
var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";

//Specifiying the commands that can be used within the terminal to obtain the current application version.
if (args.Length > 0 && (args[0] == "version" || args[0] == "--version"))
{
    //How the application version will be displayed to the user.
    Console.WriteLine($"Current App Version {version}");
    return;
}

//Version display at the top of the code, each time the program is run
// //OPTION 1
// insertBreak();
// Console.WriteLine("=================================");
// Console.WriteLine($"      Version {version}");
// Console.WriteLine("=================================");

//Displaying the Version to the user (OPTION 2)
insertBreak();
Console.WriteLine($" ========== Version {version} ===========");

var stores = StoreInfo.stores;
//Setting the filepath for the car data.
string carDataFilePath = "carData.json";
string motorbikeDataFilePath = "motorbikeData.json";
string vanDataFilePath = "vanData.json";

//Loading the car data for use within the file.
LoadCars();
//Loading the motorbike data
LoadMotorbikes();
//Loading the van data
LoadVans();

//Setting up my insertBreak function to allow me to insert breaks easily. 
//Allowing for a smoother UX.
void insertBreak()
{
    Console.WriteLine("");
}
void invalidInputDuringRental()
{
    Console.WriteLine("Sorry, this vehicle could not be found.");
}
//Saving the Van details to the JSON file.
void VansToJson()
{
    var json = JsonSerializer.Serialize(VanData.vanDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(vanDataFilePath, json);
}
//Saving the car details to the JSON file.
void CarsToJson()
{
    var json = JsonSerializer.Serialize(CarData.carDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(carDataFilePath, json);
}
//Saving the Motorbike details to the JSON file.
void MotorbikesToJson()
{
    var json = JsonSerializer.Serialize(MotorbikeData.motorbikeDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(motorbikeDataFilePath, json);
}

//Loading the CARS into the program.
void LoadCars()
{
    if(File.Exists(carDataFilePath))
    {
        string json = File.ReadAllText(carDataFilePath);
        CarData.carDict = JsonSerializer.Deserialize<Dictionary<string, Car>>(json);
    }
}
//Loading the MOTORBIKES into the program.
void LoadMotorbikes()
{
    if(File.Exists(motorbikeDataFilePath))
    {
        string json = File.ReadAllText(motorbikeDataFilePath);
        MotorbikeData.motorbikeDict = JsonSerializer.Deserialize<Dictionary<string, Motorbike>>(json);
    }
}
//Loading the VANS into the program
void LoadVans()
{
    if(File.Exists(vanDataFilePath))
    {
        string json = File.ReadAllText(vanDataFilePath);
        VanData.vanDict = JsonSerializer.Deserialize<Dictionary<string, Van>>(json);
    }
}
//If the user input does not meet the logic that has been set out.
void invalidInput()
{
    Console.WriteLine("Input INVALID. Please retry.");
}

//Adding a store to the storeList
void storeAdd()
{
    Console.Write("Please enter the name of the store you wish to add: ");
    string addStoreName = Console.ReadLine()!;
    stores.Add(addStoreName);
}
//Displaying the stores within the list
void storeListDisplay()
{
    foreach (string store in stores)
    {
        Console.WriteLine(store);
    }
}

void addCar()
{
    //Loading the cars from the JSON file. 
    LoadCars();

    insertBreak();
    Console.WriteLine("Please complete the following fields for the CAR you wish to add");
    insertBreak();
    Console.Write("MAKE: ");
    string carMake = Console.ReadLine()!;
    insertBreak();
    Console.Write("MODEL: ");
    string carModel = Console.ReadLine()!;
    insertBreak();
    Console.Write("YEAR OF MANUFACTURE: ");
    string stringCarYearOfManufacture = Console.ReadLine()!;
    int intCarYearOfManufacture = Convert.ToInt32(stringCarYearOfManufacture);
    insertBreak();
    Console.Write("MILEAGE: ");
    string stringCarMileage = Console.ReadLine()!;
    int intCarMileage = Convert.ToInt32(stringCarMileage);
    insertBreak();
    Console.Write("CATEGORY: ");
    string carCategory = Console.ReadLine()!;
    insertBreak();
    Console.Write("PRICE PER DAY: ");
    string stringPricePerDay = Console.ReadLine()!;
    int intPricePerDay = Convert.ToInt32(stringPricePerDay);
    insertBreak();
    Console.Write("PLATE: ");
    string carPlate = Console.ReadLine()!;

    //Using this opportunity to showcase another way of working around potential errors
    //For example here, the logic would get unneccessarily long and complex if I used the same method as usual
    //Whereas, here cutting that out I can account for a change in case (uppercase or lowercase, the system ignores it)
    if (!(carCategory.Equals("Small", StringComparison.OrdinalIgnoreCase)
       || carCategory.Equals("Medium", StringComparison.OrdinalIgnoreCase)
        || carCategory.Equals("Large", StringComparison.OrdinalIgnoreCase)))
    {
        invalidInput();
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
        CarInfo.CarData.carDict.Add(newCar.numberPlate, newCar);

        //Saving the Cars to the JSON file.
        CarData.SaveToJson();
        LoadCars();
        insertBreak();
        Console.WriteLine("CAR ADDED");
    } 
}

void addVan()
{ 
    insertBreak();
    Console.WriteLine("Please complete the following fields for the VAN you wish to add");
    Console.Write("MAKE: ");
    string vanMake = Console.ReadLine()!;
    insertBreak();
    Console.Write("MODEL: ");
    string vanModel = Console.ReadLine()!;
    insertBreak();
    Console.Write("YEAR OF MANUFACTURE: ");
    string stringVanYearOfManufacture = Console.ReadLine()!;
    int intVanYearOfManufacture = Convert.ToInt32(stringVanYearOfManufacture);
    insertBreak();
    Console.Write("MILEAGE: ");
    string stringVanMileage = Console.ReadLine()!;
    int intVanMileage = Convert.ToInt32(stringVanMileage);
    insertBreak();
    Console.Write("CATEGORY: ");
    string vanCategory = Console.ReadLine()!;
    insertBreak();
    Console.Write("PRICE PER DAY: ");
    string stringPricePerDay = Console.ReadLine()!;
    int intPricePerDay = Convert.ToInt32(stringPricePerDay);
    insertBreak();
    Console.Write("PLATE: ");
    string vanPlate = Console.ReadLine()!;

    //Using this opportunity to showcase another way of working around potential errors
    //For example here, the logic would get unneccessarily long and complex if I used the same method as usual
    //Whereas here, cutting that out I can account for a change in case (uppercase or lowercase, the system ignores it)
    if (!(vanCategory.Equals("Small", StringComparison.OrdinalIgnoreCase)
       || vanCategory.Equals("Medium", StringComparison.OrdinalIgnoreCase)
        || vanCategory.Equals("Large", StringComparison.OrdinalIgnoreCase)))
    {
        invalidInput();
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
        VanInfo.VanData.vanDict.Add(newVan.numberPlate, newVan);

        //Saving the Van to the JSON file.
        VanData.SaveToJson();

        insertBreak();
        Console.WriteLine("VAN ADDED");
    }
}

void addMotorbike()
{ 
    insertBreak();
    Console.WriteLine("Please complete the following fields for the MOTORBIKE you wish to add");
    Console.Write("MAKE: ");
    string motorbikeMake = Console.ReadLine()!;
    insertBreak();
    Console.Write("MODEL: ");
    string motorbikeModel = Console.ReadLine()!;
    insertBreak();
    Console.Write("YEAR OF MANUFACTURE: ");
    string stringYearOfManufacture = Console.ReadLine()!;
    int intYearOfManufacture = Convert.ToInt32(stringYearOfManufacture);
    insertBreak();
    Console.Write("MILEAGE: ");
    string stringMotorbikeMileage = Console.ReadLine()!;
    int intMotorbikeMileage = Convert.ToInt32(stringMotorbikeMileage);
    insertBreak();
    Console.Write("CATEGORY: ");
    string motorbikeCategory = Console.ReadLine()!;
    insertBreak();
    Console.Write("PRICE PER DAY: ");
    string stringPricePerDay = Console.ReadLine()!;
    int intPricePerDay = Convert.ToInt32(stringPricePerDay);
    insertBreak();
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
        MotorbikeInfo.MotorbikeData.motorbikeDict.Add(newMotorbike.numberPlate, newMotorbike);

        //Saving the Van to the JSON file.
        MotorbikeData.SaveToJson();

        insertBreak();
        Console.WriteLine("MOTORBIKE ADDED");
}
//================================================================== REMOVAL FUNCTIONS BEGIN ========================================================
//Car Removal
void removeCar(string userCarMakeSelection, string userCarModelSelection)
{
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
    File.WriteAllText(carDataFilePath, json);
}
//Van Removal
void removeVan(string userVanMakeSelection, string userVanModelSelection)
{
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
            Console.WriteLine("Could not find the van wihtin the list");
        }
    }

    var json = JsonSerializer.Serialize(VanData.vanDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(vanDataFilePath, json);
}
//Motorbike Removal 
void removeMotorbike(string userMotorbikeMakeSelection, string userMotorbikeModelSelection)
{
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
            Console.WriteLine("Could not find the car wihtin the list");
        }
    }

    var json = JsonSerializer.Serialize(MotorbikeData.motorbikeDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(motorbikeDataFilePath, json);
}
//======================================================== MAIN PROGRAM BEGINS ==========================================================================

//Trying to call the main function to show the version history

//Welcoming the user
//Getting their log-in selection
insertBreak();
    Console.WriteLine("WELCOME to CRS");
    insertBreak();
    Console.WriteLine("Please select one of the following choices:");
    insertBreak();
    Console.WriteLine("G) for GUEST");
    insertBreak();
    Console.WriteLine("S) for STAFF");
    insertBreak();
    Console.WriteLine("C) to CREATE an ACCOUNT");
    insertBreak();
    Console.Write("ENTER YOUR CHOICE: ");
    string userSelection = Console.ReadLine()!;

//If the user is a NEW USER (ACCOUNT CREATION IN THE FUTURE)
if (userSelection == "C" || userSelection == "c")
{
    Console.WriteLine("WELCOME NEW USER");
    //Insert NEW USER functions here
}

//If the user has chosen to use the system as a GUEST.
else if (userSelection == "G" || userSelection == "g")
{
    //Insert GUEST functions here
    insertBreak();
    Console.Write("Please enter your NAME: ");
    string guestName = Console.ReadLine()!;
    insertBreak();
    Console.WriteLine($"Welcome, {guestName}!");
    insertBreak();
    Console.WriteLine("Please choose from ONE of the following options:");
    insertBreak();
    Console.Write("C for CAR, M for MOTORCYCLE, V for VAN: ");
    string vehicleType = Console.ReadLine()!;

    //Cars
    if (vehicleType == "C" || vehicleType == "c")
    {
        LoadCars();
        insertBreak();
        Console.WriteLine("You have chosen CAR");
        insertBreak();

        //MAY NOT USE THIS FUNCTIONALITY UNLESS IT CAN BE INTEGRATED EASILY.

        Console.WriteLine("Which category of CAR would you like to rent?");
        insertBreak();
        Console.Write("The options are SMALL, MEDIUM or LARGE: ");
        string categoryChoice = Console.ReadLine()!;
        insertBreak();
        Console.WriteLine($"You have chosen {categoryChoice}");
        insertBreak();

        Console.Write("What is your maximum Price Per Day?: ");
        string maxPriceString = Console.ReadLine()!;
        int maxPriceInt = Convert.ToInt32(maxPriceString);
        Console.WriteLine("The options meeting your criteria are: ");
        // TRYING TO GET THIS TO WORK TO PRESENT THE USER WITH MULTIPLE PIECES OF INFORMATION
        insertBreak();
        //I HAVE REMOVED IENUMERABLE, WILL THIS STILL WORK?
        var carList =
        CarData.carDict
        .Where(car =>
            car.Value.pricePerDay <= maxPriceInt &&
            car.Value.category.Equals(categoryChoice, StringComparison.OrdinalIgnoreCase))
        .Select(car => new { car.Value.make, car.Value.model, car.Value.pricePerDay });

        foreach (var Car in carList)// i = 0, i++)
        {
            Console.WriteLine($"{Car.make} - {Car.model} - £{Car.pricePerDay}/day");
            insertBreak();
        }

        Console.WriteLine("Please fill out the following fields for the CAR you wish to RENT");
        insertBreak();
        Console.Write("MAKE: ");
        string userCarMakeSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("MODEL: ");
        string userCarModelSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("How many days would you like to rent the CAR for?: ");
        string stringNumberOfDaysRental = Console.ReadLine()!;
        int numberOfDaysRental = Convert.ToInt32(stringNumberOfDaysRental);
        insertBreak();

        Console.WriteLine($"You would like to rent the {userCarMakeSelection} {userCarModelSelection}");
        insertBreak();
        Console.WriteLine($"For {numberOfDaysRental} days?");
        Console.Write("Press Y to CONTINUE: ");
        string continueWithRental = Console.ReadLine()!;
        insertBreak();

        if (continueWithRental == "Y" || continueWithRental == "y")
        {
            var userCarSelection = CarData.carDict.Values.FirstOrDefault(Car =>
            Car.make.Equals(userCarMakeSelection, StringComparison.OrdinalIgnoreCase) &&
            Car.model.Equals(userCarModelSelection, StringComparison.OrdinalIgnoreCase));


            if (userCarSelection != null)
            {
                int totalPrice = userCarSelection.pricePerDay * numberOfDaysRental;
                Console.WriteLine($"Your total will be £{totalPrice}");

                removeCar(userCarMakeSelection, userCarModelSelection);
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
            invalidInputDuringRental();
        }

        // CAR REMOVAL FUNCTION
    }
    //Motorbikes
    else if (vehicleType == "M" || vehicleType == "m")
    {
        insertBreak();
        Console.Write("What is your maximum Price Per Day?: ");
        string maxPriceString = Console.ReadLine()!;
        int maxPriceInt = Convert.ToInt32(maxPriceString);
        insertBreak();
        Console.WriteLine("Your Options are: ");
        insertBreak();

        var motorbikeList =
            MotorbikeData.motorbikeDict
                .Where(motorbike =>
                (motorbike.Value.pricePerDay <= maxPriceInt))
                .Select(motorbike => new { motorbike.Value.make, motorbike.Value.model, motorbike.Value.pricePerDay });
        foreach (var motorbike in motorbikeList)
        {
            Console.WriteLine($"{motorbike.make} - {motorbike.model} - £{motorbike.pricePerDay}/day");
            insertBreak();
        }
        Console.WriteLine("Please fill out the following fields for the MOTORBIKE you wish to RENT");
        insertBreak();
        Console.Write("MAKE: ");
        string userMotorbikeMakeSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("MODEL: ");
        string userMotorbikeModelSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("How many days would you like to rent the MOTORBIKE for?: ");
        string stringNumberOfDaysRental = Console.ReadLine()!;
        int numberOfDaysRental = Convert.ToInt32(stringNumberOfDaysRental);
        insertBreak();

        Console.WriteLine($"You would like to rent the {userMotorbikeMakeSelection} {userMotorbikeModelSelection}");
        insertBreak();
        Console.WriteLine($"For {numberOfDaysRental} days?");
        Console.Write("Press Y to CONTINUE: ");
        string continueWithRental = Console.ReadLine()!;
        insertBreak();

        if (continueWithRental == "Y" || continueWithRental == "y")
        {
            var userMotorbikeSelection = MotorbikeData.motorbikeDict.Values.FirstOrDefault(Motorbike =>
            Motorbike.make.Equals(userMotorbikeMakeSelection, StringComparison.OrdinalIgnoreCase) &&
            Motorbike.model.Equals(userMotorbikeModelSelection, StringComparison.OrdinalIgnoreCase));

            if (userMotorbikeSelection != null)
            {
                int totalPrice = userMotorbikeSelection.pricePerDay * numberOfDaysRental;
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
    //Vans
    else if (vehicleType == "V" || vehicleType == "v")
    {
        insertBreak();
        Console.WriteLine("Which category of VAN would you like to rent?");
        insertBreak();
        Console.Write("The options are SMALL, MEDIUM or LARGE: ");
        string categoryChoice = Console.ReadLine()!;
        insertBreak();
        Console.WriteLine($"You have chosen {categoryChoice}");
        insertBreak();

        Console.Write("What is your maximum Price Per Day?: ");
        string maxVanPriceString = Console.ReadLine()!;
        int maxVanPriceInt = Convert.ToInt32(maxVanPriceString);
        insertBreak();
        Console.WriteLine("Your Options are: ");

        insertBreak();

        var vanList =
            VanData.vanDict
                .Where(van =>
                (van.Value.pricePerDay <= maxVanPriceInt))
                .Select(van => new { van.Value.make, van.Value.model, van.Value.pricePerDay });

        foreach (var van in vanList)
        {
            Console.WriteLine($"{van.make} - {van.model} - £{van.pricePerDay}/day");
            insertBreak();
        }
        Console.WriteLine("Please fill out the following fields for the VAN you wish to RENT");
        insertBreak();
        Console.Write("MAKE: ");
        string userVanMakeSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("MODEL: ");
        string userVanModelSelection = Console.ReadLine()!;
        insertBreak();
        Console.Write("How many days would you like to rent the VAN for?: ");
        string stringNumberOfDaysVanRental = Console.ReadLine()!;
        int numberOfDaysVanRental = Convert.ToInt32(stringNumberOfDaysVanRental);
        insertBreak();

        Console.WriteLine($"You would like to rent the {userVanMakeSelection} {userVanModelSelection}");
        Console.WriteLine($"For {numberOfDaysVanRental} days?");
        insertBreak();
        Console.Write("Press Y to CONTINUE: ");
        string continueWithVanRental = Console.ReadLine()!;
        insertBreak();

        if (continueWithVanRental == "Y" || continueWithVanRental == "y")
        {
            var userVanSelection = VanData.vanDict.Values.FirstOrDefault(Van =>
            Van.make.Equals(userVanMakeSelection, StringComparison.OrdinalIgnoreCase) &&
            Van.model.Equals(userVanModelSelection, StringComparison.OrdinalIgnoreCase));

            if (userVanSelection != null)
            {
                int totalPrice = userVanSelection.pricePerDay * numberOfDaysVanRental;
                Console.WriteLine($"Your total will be £{totalPrice}");

                removeVan(userVanMakeSelection, userVanModelSelection);
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
            invalidInput();
        }
    }
}
//If the user wishes to sign in as a member of STAFF
else if (userSelection == "S" || userSelection == "s")
{
    //Insert STAFF functions here
    insertBreak();
    Console.WriteLine("WELCOME STAFF");
    insertBreak();
    Console.WriteLine("Which of the following functions would you like to perform?");
    insertBreak();
    Console.WriteLine("A) ADD VEHICLES");
    insertBreak();
    Console.WriteLine("R) REMOVE VEHICLES");
    insertBreak();
    Console.WriteLine("E) EDIT STORE LIST");
    insertBreak();
    Console.Write("Please Enter Your Choice: ");
    string? staffMenuChoice = Console.ReadLine();
    insertBreak();

    if (staffMenuChoice == "A" || staffMenuChoice == "a")
    {
        Console.WriteLine("Would you like to add");
        insertBreak();
        Console.WriteLine("C) CAR");
        insertBreak();
        Console.WriteLine("M) MOTORBIKE");
        insertBreak();
        Console.WriteLine("OR");
        insertBreak();
        Console.WriteLine("V) VAN");
        insertBreak();
        Console.Write("PLEASE ENTER YOUR CHOICE: ");
        string addVehicleType = Console.ReadLine()!;
        insertBreak();

        if (addVehicleType == "C" || addVehicleType == "c")
        {
            Console.Write("Would you like to ADD MULTIPLE CARS?: ");
            string addMultipleCars = Console.ReadLine()!;
            insertBreak();

            if (addMultipleCars == "Yes" || addMultipleCars == "yes" || addMultipleCars == "Y" || addMultipleCars == "y")
            {
                Console.Write("How many cars would you like to add?: ");
                string stringHowManyCars = Console.ReadLine()!;
                int intHowManyCars = Convert.ToInt32(stringHowManyCars);
                insertBreak();

                while (intHowManyCars > 0)
                {
                    intHowManyCars--;
                    addCar();

                }
            }
        }
        else if (addVehicleType == "M" || addVehicleType == "m")
        {
            Console.Write("Would you like to ADD MULTIPLE MOTORBIKES?: ");
            string addMultipleMotorbikes = Console.ReadLine()!;

            if (addMultipleMotorbikes == "Yes" || addMultipleMotorbikes == "yes" || addMultipleMotorbikes == "Y" || addMultipleMotorbikes == "y")
            {
                Console.Write("How many motorbikes would you like to add?: ");
                string stringHowManyMotorbikes = Console.ReadLine()!;
                int intHowManyMotorbikes = Convert.ToInt32(stringHowManyMotorbikes);

                while (intHowManyMotorbikes > 0)
                {
                    intHowManyMotorbikes--;
                    addMotorbike();
                }
            }
        }
        else if (addVehicleType == "V" || addVehicleType == "v")
        {
            Console.Write("Would you like to ADD MULTIPLE VANS?: ");
            string addMultipleVans = Console.ReadLine()!;

            if (addMultipleVans == "Yes" || addMultipleVans == "yes" || addMultipleVans == "Y" || addMultipleVans == "y")
            {
                Console.Write("How many vans would you like to add?: ");
                string stringHowManyVans = Console.ReadLine()!;
                int intHowManyVans = Convert.ToInt32(stringHowManyVans);

                while (intHowManyVans > 0)
                {
                    intHowManyVans--;
                    addVan();
                }
            }
        }
        else
        {
            //Provide Error Message
            invalidInput();
            Console.WriteLine("WRONG SECTION");
        }
    }
    else if (staffMenuChoice == "R" || staffMenuChoice == "r")
    {
        //Remove Vehicle from list section
    }
    else if (staffMenuChoice == "E" || staffMenuChoice == "e")
    {
        Console.WriteLine("The current list of stores will be displayed below: ");
        insertBreak();

        storeListDisplay();

        insertBreak();
        Console.Write("Would you like to Add a new store to the list?: ");
        string decision = Console.ReadLine()!;
        if (decision == "Yes" || decision == "yes")
        {
            storeAdd();
            Console.WriteLine("Would you like to add another store?: ");
            string addMoreStores = Console.ReadLine()!;

            if (addMoreStores == "Yes" || addMoreStores == "yes")
            {
                storeAdd();
            }
            else
            {
                Console.WriteLine("You will now be logged out, THANK YOU.");
                return;
            }
        }
        else if (decision == "No" || decision == "no")
        {
            Console.WriteLine("Would you like to remove a store from the list?: ");
            string removeStore = Console.ReadLine()!;

            if (removeStore == "Yes" || removeStore == "yes")
            {
                Console.WriteLine("Please enter the name of the store you wish to remove from the list");
                Console.WriteLine("OR");
                Console.WriteLine("Press V to view the list");
                Console.Write("Enter Your Choice: ");
                string choice = Console.ReadLine()!;

                if (choice == "V" || choice == "v")
                {
                    storeListDisplay();
                }
                else
                {
                    invalidInput();
                }
            }
        }
        else
        {
            //Provide Error Message
            invalidInput();
            Console.WriteLine("WRONG SECTION");
        }
    }
}

// ============================================================================== MAIN PROGRAM ENDS ===================================================
//Potential Developments

//We have the potential to add in a new dataset containing supercars/luxury vehicles for rental.
//This will give us the opportunity to use a new type potentially other than dictionary if applciable.
//Should check the date and only take the car out of the system on the correct date.

//In the assessment application

//You need to take arguments
//And also handle them properly

//The --3 argument will show the version of the program.
//This is a very common command line argument

//Do we need to use command line arguments multiple times or only once to show we know how to use them?

//You need to include the things that we have learnt within the assessment so that we can get higher marks.
