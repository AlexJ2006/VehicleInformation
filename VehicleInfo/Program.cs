// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Text.Json;
//Allowing program.cs to access my dictionary (info) files.
using CarInfo;
using MotorbikeInfo;
using VanInfo;
using storeList;
using System.Reflection;
using UserData;
using VehicleInfo;
using System.Runtime.InteropServices.Marshalling;

StaffData.LoadJsonData();

//Loading the Car Data into the program.
CarData.LoadJsonData();


//StaffData.LoadJsonData();

UserDatabaseManager.InitializeDatabase();

//Showing the user the version as per the "Version" tag within the VehicleInfo.csproj file.
var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";

//Specifiying the commands that can be used within the terminal to obtain the current application version.
if (args.Length > 0 && (args[0] == "version" || args[0] == "--version"))
{
    //How the application version will be displayed to the user.
    Console.WriteLine($"Current App Version {version}");
    return;
}

var stores = StoreInfo.stores;
//Setting the filepath for the car data.
//string carDataFilePath = "carData.json";
string motorbikeDataFilePath = "motorbikeData.json";
string vanDataFilePath = "vanData.json";

//Loading the car data for use within the file.
VehicleManagement.LoadCars();
//Loading the motorbike data
VehicleManagement.LoadMotorbikes();
//Loading the van data
VehicleManagement.LoadVans();

//Setting up my insertBreak function to allow me to insert breaks easily. 
//Allowing for a smoother UX.
void insertBreak()
{
    Console.WriteLine("");
}
void staffModeAlert()
{
    Console.WriteLine("**************** USER ALERT ****************");
    Console.WriteLine("To enter STAFF MODE please enter the following when prompted");
    Console.WriteLine("--staff staffUsername staffPassword");
    Console.WriteLine("**************** USER ALERT ****************");
}
void LogIn()
{
    insertBreak();
    Console.WriteLine("Do you currentl have an account?");
    insertBreak();
    Console.WriteLine("Please enter: ");
    insertBreak();
    Console.WriteLine("Y for YES");
    Console.WriteLine("OR");
    Console.Write("N for NO ");
    string userHasAnAccount = Console.ReadLine()!;
    
    if (userHasAnAccount == "Y" || userHasAnAccount == "y")
    {
        //Obtaining the user's details.
        Console.WriteLine("Please enter your credentials");
        Console.Write("USER ID: ");
        string userID = Console.ReadLine()!;
        insertBreak();
        Console.Write("PASSWORD: ");
        string password = Console.ReadLine()!;

        if (UserDatabaseManager.ValidateUserLogIn(userID, password))
        {
            //if the user can/has been logged in
            Console.WriteLine("YOU HAVE BEEN LOGGED IN");
        }
        else
        {
            //if the user can't be logged in 
            Console.WriteLine("LOGIN UNSUCCESSFUL");
            Console.WriteLine("The Program will now terminate. PLEASE RETRY.");
            return;
        }
        //Complete the log in functions
    }
    else if (userHasAnAccount == "N" || userHasAnAccount == "n")
    {
        Console.Write("Would you like to CREATE an account?: ");
        string createAccount = Console.ReadLine()!;

        if (createAccount == "Y" || createAccount == "y")
        {
            //The user creates their account here.
            RegisterNewUser();
        }
        else if (createAccount == "N" || createAccount == "n")
        {
            Console.Write("Would you like to continue as a GUEST?: ");
            string continueAsGuest = Console.ReadLine()!;

            if(continueAsGuest == "Y" || continueAsGuest == "y")
            {
                //Tell the user that they are not able to rent cars, they can only browse the available cars.
                //The user continues as a guest.
            }
        }
    }
}
void RegisterNewUser()
{
    Console.WriteLine("Please Complete the following Steps to create your account");
    insertBreak();
    Console.WriteLine("Please note, the user ID must ONLY contain NUMBERS ");
    insertBreak();
    Console.Write("UserID: ");
    string stringUserID = Console.ReadLine()!;
    int userID = Convert.ToInt32(stringUserID);
    insertBreak();
    Console.WriteLine("Please note, the password MUST contain UPPER and LOWER cases and NUMBERS");
    Console.Write("Password:");
    string stringUserPassword = Console.ReadLine()!;
    // int UserPassword = Convert.ToInt32(stringUserPassword);
    insertBreak();
    Console.Write("First Name: ");
    string firstName = Console.ReadLine()!;
    insertBreak();
    Console.Write("Last Name: ");
    string lastName = Console.ReadLine()!;
    insertBreak();
    Console.WriteLine("DoB: ");
    string stringDoB = Console.ReadLine()!;
    // int DoB = Convert.ToInt32(stringDoB);
    insertBreak();
    Console.Write("Contact Number: ");
    string stringContactNumber = Console.ReadLine()!;
    int contactNumber = Convert.ToInt32(stringContactNumber);

    UserDatabaseManager.RegisteredUser(stringUserID, stringUserPassword, firstName, lastName, stringDoB, stringContactNumber);
}
//Loading the CARS into the program.
void LoadCars()
{
    CarData.LoadJsonData();
}

//Loading the MOTORBIKES into the program.

//Loading the VANS into the program
void LoadVans()
{
    VanData.LoadJsonData();
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

// ================================================================= USER SPECIFIC FUNCTIONS ========================================================
void staffModeFunctions()
{

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
                    VehicleManagement.addCar();

                }
            }
            else
            {
                addCar();
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
            else
            {
                //One instance of the Add Motorbike class occurs rather than multiple
                insertBreak();
                addMotorbike();
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
                    VehicleManagement.addVan();
                }
            }
            else
            {
                insertBreak();
                addVan();
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
void adminFunctions()
    {
        Console.WriteLine("Please select a function from the following");
        insertBreak();
        Console.WriteLine("A) ADD staff member");
        insertBreak();
        Console.WriteLine("R) REMOVE staff member");
        insertBreak();
        Console.WriteLine("V) VIEW staff member lsit");
        insertBreak();
        Console.Write("ENTER YOUR CHOICE:");
        string adminFunctionChoice = Console.ReadLine()!;

        if (adminFunctionChoice == "A" || adminFunctionChoice == "a")
        {
            insertBreak();
            Console.Write("STAFF ID: ");
            string stringStaffID = Console.ReadLine()!;
            int staffID = Convert.ToInt32(stringStaffID);
            Console.Write("FIRST NAME: ");
            string firstName = Console.ReadLine()!;
            Console.Write("LAST NAME: ");
            string lastName = Console.ReadLine()!;

            Staff newStaff = new Staff
            {
                staffID = staffID,
                firstName = firstName,
                lastName = lastName
            };
            //Adding the car to the dictionary.
            StaffData.staffDict.Add(newStaff.staffID, newStaff);

            //Saving the Cars to the JSON file.
            CarData.SaveToJson();
            Console.WriteLine("CAR ADDED");

        }
        else if (adminFunctionChoice == "R" || adminFunctionChoice == "r")
        {

        }
        else if (adminFunctionChoice == "V" || adminFunctionChoice == "v")
        {

        }
        else
        {
            invalidInput();
        }
    }
    //================================================================== REMOVAL FUNCTIONS BEGIN ========================================================
    //Car Removal
    void removeCar(string userCarMakeSelection, string userCarModelSelection)
    {
        
    }
    //Van Removal
    void removeVan(string userVanMakeSelection, string userVanModelSelection)
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
                Console.WriteLine("Could not find the van wihtin the list");
            }
        }

        var json = JsonSerializer.Serialize(VanData.vanDict, new JsonSerializerOptions { WriteIndented = true });
        VanData.SaveToJson();
    }
    //Motorbike Removal 
    void removeMotorbike(string userMotorbikeMakeSelection, string userMotorbikeModelSelection)
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
                Console.WriteLine("Could not find the car wihtin the list");
            }
        }

        var json = JsonSerializer.Serialize(MotorbikeData.motorbikeDict, new JsonSerializerOptions { WriteIndented = true });
        MotorbikeData.SaveToJson();
    }

    //Staff Function
    void userStaffMode(string[] args)
    {
        // Expect: --staff <id> <lastName>
        if (args.Length == 3 && args[0].Equals("--staff", StringComparison.OrdinalIgnoreCase))
        {
            if (!int.TryParse(args[1], out int id))
            {
                Console.WriteLine("Invalid staff ID format.");
                return;
            }

            string lastName = args[2];

            if (StaffData.staffDict.TryGetValue(id, out Staff staff) &&
                staff.lastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"WELCOME STAFF MEMBER {staff.GetName()}");
                staffModeFunctions();
                return;
            }

            Console.WriteLine("ACCESS DENIED");
            return;
        }

        // Just tell user invalid input — DO NOT RECALL the function
        Console.WriteLine("INVALID INPUT. PLEASE RETRY.");
    }


    //======================================================== MAIN PROGRAM BEGINS ==========================================================================

    //Trying to call the main function to show the version history

    //Welcoming the user
    //Getting their log-in selection

    insertBreak();
    //Displaying the Version.
    insertBreak();
    Console.WriteLine($" ================ Version {version} ================");
    insertBreak();
    Console.WriteLine("WELCOME to CRS");
    insertBreak();
    //The alert for the staff mode selection.
    staffModeAlert();
    Console.Write("ENTER COMMAND: ");
    string enterStaff = Console.ReadLine()!;
    string[] staffArgs = enterStaff.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    userStaffMode(staffArgs);



    insertBreak();
    Console.WriteLine("Please select one of the following choices:");
    insertBreak();
    Console.WriteLine("G) for GUEST");
    insertBreak();
    Console.WriteLine("C) to CREATE an ACCOUNT");
    insertBreak();
    Console.WriteLine("L) to LOG IN to an EXISTING ACCOUNT");
    insertBreak();
    Console.Write("ENTER YOUR CHOICE: ");
    string userSelection = Console.ReadLine()!.Trim().ToUpper();



    if (userSelection == "C")
    {
        insertBreak();
        Console.WriteLine("WELCOME NEW USER");
        // Insert NEW USER functions here
    }
    else if (userSelection == "L")
    {
        insertBreak();
        Console.WriteLine("LOGGING YOU IN...");
    }
    else if (userSelection == "G")
    {
        insertBreak();
        Console.WriteLine("ENTERING GUEST MODE...");
    }
    else
    {
        insertBreak();
        Console.WriteLine("INVALID OPTION. PLEASE TRY AGAIN.");
    }

//If the user has chosen to use the system as a GUEST.
if (userSelection == "G" || userSelection == "g")
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

        foreach (var Car in carList)
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
        LoadMotorbikes();

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
        LoadVans();

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

else if (userSelection == "L" || userSelection == "l")
{
    LogIn();
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

//Make sure that as many exceptions as possible are covered.
//Could use the try functions for this, try...while...
//Exceptions can be seen my hovering over the top of functions.

//For premium cars, I could use a databse which would allow me to use the try, catch, finally statements.
//The above statements are included within the week 6 work for robustness.
//The file needs to be within the bin file (at the same level as the exe document).
//I could have a list of the filenames (in a normal list).
//And then the user can select a file to open.

//Need to continue working on the user create account function.
//Need to continue implementing the User log in function.

//Make sure to catch exceptions throughout the code.
//Even if it makes the code look messy

//Could have it so the admin user can view all of the staff details by printing them from the file. 
//This could work by using the week 6 content and using try, catch and exception handling.

//Could potentially aslo put the guest section into a function.

//Could use IEnumerable for the storelist.

//Look at putting the functions into classes and moving them to other files and then calling them into the program.cs which will just be used for calling the functions.
