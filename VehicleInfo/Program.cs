// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

List<Car> carList = new List<Car>();
Car c1 = new Car();
c1.make = "BMW";
c1.plate = "DN61OJF";
c1.yearOfManufacture = 2025;
carList.Add(c1);

Car c2 = new Car();
c2.make = "Peugeot";
c2.plate = "AF25BFF";
c2.yearOfManufacture = 2011;
carList.Add(c2);

Car c3 = new Car();
c3.make = "Alpha Romeo";
c3.plate = "FJ74 AMJ";
c3.yearOfManufacture = 2024;
carList.Add(c3);

Car c4 = new Car();
c4.make = "Smart";
c4.plate = "AJ72 FJB";
c4.yearOfManufacture = 2022;
carList.Add(c4);


List<Car> carAgeOrder = carList.OrderBy(car => car.yearOfManufacture).ToList();

foreach (Car car in carAgeOrder)
{
    Console.WriteLine(car.yearOfManufacture);
}
class Car
{
    public string make;

    public string plate;

    public int yearOfManufacture;
}

