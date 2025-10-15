// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
void insertBreak()
{
    Console.WriteLine("");
}

void invalidInput()
{
    Console.WriteLine("Input INVALID. Please retry.");
}

Dictionary<string, Car> carDict = new Dictionary<string, Car>();
//First Car (large)
Car c1 = new Car();
c1.make = "Ford";
c1.model = "Galaxy";
c1.yearOfManufacture = 2022;
c1.mileage = 60897;
c1.category = "Large";
c1.pricePerDay = 150;
c1.numberPlate = "MD62JKD";
carDict.Add(c1.numberPlate, c1);
//Second Car (small)
Car c2 = new Car();
c2.make = "Dacia";
c2.model = "Sandero";
c2.yearOfManufacture = 2021;
c2.mileage = 75061;
c2.category = "Small";
c2.pricePerDay = 80;
c2.numberPlate = "DL21OLP";
carDict.Add(c2.numberPlate, c2);
//Third Car (Medium)
Car c3 = new Car();
c3.make = "Nissan";
c3.model = "Quashqai";
c3.yearOfManufacture = 2020;
c3.mileage = 50982;
c3.category = "Medium";
c3.pricePerDay = 120;
c3.numberPlate = "NM60LDS";
carDict.Add(c3.numberPlate, c3);
//Fourth Car (small)
Car c4 = new Car();
c4.make = "Smart";
c4.model = "ForFour";
c4.yearOfManufacture = 2015;
c4.mileage = 74982;
c4.category = "Small";
c4.pricePerDay = 85;
c4.numberPlate = "WF15HGG";
carDict.Add(c4.numberPlate, c4);
//Fifth Car (small)
Car c5 = new Car();
c5.make = "Toyota";
c5.model = "Aygo";
c5.yearOfManufacture = 2024;
c5.mileage = 13521;
c5.category = "Small";
c5.pricePerDay = 100;
c5.numberPlate = "MC24NEW";
carDict.Add(c5.numberPlate, c5);

//Motorbikes
Dictionary<string, Motorbike> motorbikeDict = new Dictionary<string, Motorbike>();
//First Bike
Motorbike b1 = new Motorbike();
b1.make = "Harley Davidson";
b1.model = "RoadGlide";
b1.yearOfManufacture = 2023;
b1.mileage = 25856;
b1.pricePerDay = 200;
b1.numberPlate = "HD23LOW";
motorbikeDict.Add(b1.numberPlate, b1);
//Second Bike
Motorbike b2 = new Motorbike();
b2.make = "BMW";
b2.model = "F900 GS";
b2.yearOfManufacture = 2025;
b2.mileage = 1298;
b2.pricePerDay = 180;
b2.numberPlate = "BM25SPD";
motorbikeDict.Add(b2.numberPlate, b2);
//Third Bike
Motorbike b3 = new Motorbike();
b3.make = "BMW";
b3.model = "R1300 GS Adventure";
b3.yearOfManufacture = 2024;
b3.mileage = 11092;
b3.pricePerDay = 200;
b3.numberPlate = "SP24LOR";
motorbikeDict.Add(b3.numberPlate, b3);
//Fourth Bike
Motorbike b4 = new Motorbike();
b4.make = "Honda";
b4.model = "RoadGlide";
b4.yearOfManufacture = 2019;
b4.mileage = 28933;
b4.pricePerDay = 200;
b4.numberPlate = "HN19DAR";
motorbikeDict.Add(b4.numberPlate, b4);

//Vans
Dictionary<string, Van> vanDict = new Dictionary<string, Van>();
//First Van
Van v1 = new Van();
v1.make = "Mercedes";
v1.model = "Sprinter";
v1.yearOfManufacture = 2019;
v1.mileage = 125927;
v1.category = "Large";
v1.pricePerDay = 200;
v1.numberPlate = "MD69SPR";
vanDict.Add(v1.numberPlate, v1);
//Second Van
Van v2 = new Van();
v2.make = "Volkswagen";
v2.model = "Caddy";
v2.yearOfManufacture = 2023;
v2.mileage = 56929;
v2.category = "Small";
v2.pricePerDay = 200;
v2.numberPlate = "VW23MDS";
vanDict.Add(v2.numberPlate, v2);
//Third Van
Van v3 = new Van();
v3.make = "Ford";
v3.model = "Transit";
v3.yearOfManufacture = 2020;
v3.mileage = 84562;
v3.category = "Small";
v3.pricePerDay = 180;
v3.numberPlate = "BM28JHS";
vanDict.Add(v3.numberPlate, v3);
//Fourth Van
Van v4 = new Van();
v4.make = "Renault";
v4.model = "Kangoo";
v4.yearOfManufacture = 2023;
v4.mileage = 98233;
v4.category = "Small";
v4.pricePerDay = 185;
v4.numberPlate = "JD82DSK";
vanDict.Add(v4.numberPlate, v4);

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
        Console.WriteLine($"You have chosen{categoryChoice}");

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
                (maxPriceInt == null || car.Value.pricePerDay <= maxPriceInt)
                &&
                (car.Value.category == categoryChoice))
                .Select(car => new {car.Value.make, car.Value.model, car.Value.pricePerDay});
        foreach (var Car in carList)
        {
            Console.WriteLine($"{Car.make} - {Car.model} - £{Car.pricePerDay}/day");
            insertBreak();
        }

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
                (maxPriceInt == null || motorbike.Value.pricePerDay <= maxPriceInt))
                .Select(motorbike => new {motorbike.Value.make, motorbike.Value.model, motorbike.Value.pricePerDay});
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
                (maxPriceInt == null || van.Value.pricePerDay <= maxPriceInt)
                &&
                (van.Value.category == categoryChoice))
                .Select(van => new {van.Value.make, van.Value.model, van.Value.pricePerDay});
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
}
else
{
    invalidInput();
}

class Car
{
    public string make; //--
    public string model; //--
    public int yearOfManufacture; //--
    public int mileage; //--
    public string category; //--
    public int pricePerDay; //--
    public string numberPlate; //--
}
class Motorbike
{
    public string make;
    public string model;
    public int yearOfManufacture;
    public int mileage;
    public int pricePerDay;
    public string numberPlate;
}

class Van
{
    public string make;
    public string model;
    public int yearOfManufacture;
    public int mileage;
    public string category;
    public int pricePerDay;
    public string numberPlate;
}


//Potential Developments

//We have the potential to add in a new dataset containing supercard/luxury vehicles for rental. 
//This will give us the opportunity to use a new type potentially other than dictionary if applciable. 