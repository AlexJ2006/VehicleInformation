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
//First Car
Car c1 = new Car();
c1.make = "Ford";
c1.model = "Galaxy";
c1.yearOfManufacture = 2022;
c1.mileage = 60897;
c1.category = "Large";
c1.pricePerDay = 150;
c1.numberPlate = "MD62JKD";
carDict.Add(c1.numberPlate, c1);
//Second Car
Car c2 = new Car();
c2.make = "Dacia";
c2.model = "Sandero";
c2.yearOfManufacture = 2021;
c2.mileage = 75061;
c2.category = "Small";
c2.pricePerDay = 80;
c2.numberPlate = "DL21OLP";
carDict.Add(c2.numberPlate, c2);
//Third Car
Car c3 = new Car();
c3.make = "Nissan";
c3.model = "Quashqai";
c3.yearOfManufacture = 2020;
c3.mileage = 50982;
c3.category = "Medium";
c3.pricePerDay = 120;
c3.numberPlate = "NM60LDS";
carDict.Add(c3.numberPlate, c3);

insertBreak();
Console.WriteLine("WELCOME to CRS");
insertBreak();
Console.WriteLine("Please select one of the following choices:");
insertBreak();
Console.WriteLine("G for GUEST");
insertBreak();
Console.WriteLine("S for STAFF");
insertBreak();
Console.WriteLine("C for NEW USER");
insertBreak();
Console.Write("ENTER YOUR CHOICE: ");
string userSelection = Console.ReadLine()!;

if (userSelection == "C" || userSelection == "c")
{
    Console.WriteLine("WELCOME NEW USER");
    //Insert NEW USER functions here
}
else if (userSelection == "G" || userSelection == "g")
{
    //Insert GUEST functions here
    Console.Write("Please enter your NAME");
    string guestName = Console.ReadLine()!;
    Console.WriteLine($"Welcome, {guestName}");
    Console.WriteLine("Please choose from ONE of the following options:");
    Console.WriteLine("C for CAR, M for MOTORCYCLE, V for VAN");
    string vehicleType = Console.ReadLine()!;

    if (vehicleType == "C" || vehicleType == "c")
    {
        
    }
    else if (vehicleType == "M" || vehicleType == "m")
    {

    }
    else if (vehicleType == "V" || vehicleType == "v")
    {

    }
    else
    {
        invalidInput();
    }
}
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

