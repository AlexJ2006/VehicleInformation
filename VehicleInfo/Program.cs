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

var stores = StoreInfo.stores;
//Initialising the variables for the car, motorbike and van dictionaries being pulled from the other file.
var carDict = CarData.carDict;
var motorbikeDict = MotorbikeData.motorbikeDict;
var vanDict = VanData.vanDict;
//Setting the filepath for the car data.
string carDataFilePath = "carData.json";

//Loading the car data for use within the file.
LoadCars();

void insertBreak()
{
    Console.WriteLine("");
}

//Saving the car details to the JSON file.
void CarsToJson()
{
    var json = JsonSerializer.Serialize(carDict, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(carDataFilePath, json);
}

//Loading the current cars within the dictionary from the JSON file.
void LoadCars()
{
    if(File.Exists(carDataFilePath))
    {
        string json = File.ReadAllText(carDataFilePath);
        carDict = JsonSerializer.Deserialize<Dictionary<string, Car>>(json);
    }
}
void invalidInput()
{
    Console.WriteLine("Input INVALID. Please retry.");
}

void storeAdd()
{
    Console.Write("Please enter the name of the store you wish to add: ");
    string addStoreName = Console.ReadLine()!;
    stores.Add(addStoreName);
}

void storeListDisplay()
{
    foreach (string store in stores)
    {
        Console.WriteLine(store);
    }
}

void addCar()
{
    insertBreak();
    Console.WriteLine("Please complete the following fields for the vehicle you wish to add");
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

        insertBreak();
        Console.WriteLine("CAR ADDED");
    }


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
            insertBreak();
            Console.WriteLine("You have chosen CAR");
            insertBreak();

            //MAY NOT USE THIS FUNCTIONALITY UNLESS IT CAN BE INTEGRATED EASILY.

            Console.WriteLine("Which category of CAR would you like to rent?");
            Console.Write("The options are SMALL, MEDIUM or LARGE: ");
            string categoryChoice = Console.ReadLine()!;
            insertBreak();
            Console.WriteLine($"You have chosen {categoryChoice}");

            Console.Write("What is your maximum Price Per Day?: ");
            string maxPriceString = Console.ReadLine()!;
            int maxPriceInt = Convert.ToInt32(maxPriceString);
            Console.WriteLine("The options meeting your criteria are: ");
            // TRYING TO GET THIS TO WORK TO PRESENT THE USER WITH MULTIPLE PIECES OF INFORMATION
            insertBreak();
            //I HAVE REMOVED IENUMERABLE, WILL THIS STILL WORK?
            var carList =
                carDict
                    .Where(car =>
                    (car.Value.pricePerDay <= maxPriceInt)
                    &&
                    (car.Value.category == categoryChoice))
                    .Select(car => new { car.Value.make, car.Value.model, car.Value.pricePerDay });
            foreach (var Car in carList)// i = 0, i++)
            {
                Console.WriteLine($"{Car.make} - {Car.model} - £{Car.pricePerDay}/day");
                insertBreak();
            }

            // Console.Write("Please select one of the above options or press T to terminate the program");
            // string carSelection = Console.ReadLine();

            // if(carSelection == //a certain item
            // //Need to move the bracket that is currently below, up to the top once the note has been removed
            // )

            // {

            // }
            // else if(carSelection == "T" || carSelection == "t")
            // {
            //     return;
            // }
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
                motorbikeDict
                    .Where(motorbike =>
                    (motorbike.Value.pricePerDay <= maxPriceInt))
                    .Select(motorbike => new { motorbike.Value.make, motorbike.Value.model, motorbike.Value.pricePerDay });
            foreach (var bike in motorbikeList)
            {
                Console.WriteLine($"{bike.make} - {bike.model} - £{bike.pricePerDay}/day");
                insertBreak();
            }
        }
        //Vans
        else if (vehicleType == "V" || vehicleType == "v")
        {
            Console.WriteLine("Which category of VAN would you like to rent?");
            Console.Write("The options are SMALL, MEDIUM or LARGE: ");
            string categoryChoice = Console.ReadLine()!;
            insertBreak();
            Console.WriteLine($"You have chosen {categoryChoice}");
            insertBreak();

            Console.Write("What is your maximum Price Per Day?: ");
            string maxPriceString = Console.ReadLine()!;
            int maxPriceInt = Convert.ToInt32(maxPriceString);
            Console.WriteLine("Your Options are: ");

            insertBreak();
            var vanList =
                vanDict
                    .Where(van =>
                    (van.Value.pricePerDay <= maxPriceInt)
                    &&
                    (van.Value.category == categoryChoice))
                    .Select(van => new { van.Value.make, van.Value.model, van.Value.pricePerDay });
            foreach (var van in vanList)
            {
                Console.WriteLine($"{van.make} - {van.model} - £{van.pricePerDay}/day");
                insertBreak();
            }
        }
        //If the user has not inputted C, M or V...
        else
        {
            invalidInput();
        }

    }
    //If the user wishes to sign in as a member of STAFF
    else if (userSelection == "S" || userSelection == "s")
    {
        //Insert STAFF functions here
        Console.WriteLine("WELCOME STAFF");
        Console.WriteLine("Which of the following functions would you like to perform?");
        Console.WriteLine("A) ADD VEHICLES");
        Console.WriteLine("R) REMOVE VEHICLES");
        Console.WriteLine("E) EDIT STORE LIST");
        string? staffMenuChoice = Console.ReadLine();
        insertBreak();

        if (staffMenuChoice == "A" || staffMenuChoice == "a")
        {
            Console.Write("Would you like to ADD MULTIPLE CARS?: ");
            string addMultipleCars = Console.ReadLine()!;

            if (addMultipleCars == "Yes" || addMultipleCars == "yes" || addMultipleCars == "Y" || addMultipleCars == "y")
            {
                Console.Write("How many cars would you like to add?: ");
                string stringHowManyCars = Console.ReadLine()!;
                int intHowManyCars = Convert.ToInt32(stringHowManyCars);

                while (intHowManyCars > 0)
                {
                    intHowManyCars--;
                    addCar();

                }
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
                    // else if (choice == )
                    // {
                    //         // IF THE CHOICE THE USER HAS MADE IS EQUAL TO ONE OF THE ITEMS WITHIN THE LIST THEN SOMETHING SHOULD HAPPEN IN HERE.
                    // }
                }
            }
        }
        else
        {
            //Provide Error Message
            invalidInput();
        }
    }
    else
    {
        invalidInput();

    }
}
//Potential Developments

//We have the potential to add in a new dataset containing supercars/luxury vehicles for rental.
//This will give us the opportunity to use a new type potentially other than dictionary if applciable.