using System.Collections.Generic;

namespace MotorbikeInfo
{
    public static class MotorbikeData
    {
        public static Dictionary<string, Motorbike> motorbikeDict = new Dictionary<string, Motorbike>();
        static MotorbikeData()
        {
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

            //ADD MORE MOTORBIKES HERE
            //AGAIN, ALL THE BIKES ABOVE HAVE BEEN IMPLEMENTED MANUALLY FOR TESTING PURPOSES
        }

    }

    public class Motorbike
    {
        public string? make;
        public string? model;
        public int yearOfManufacture;
        public int mileage;
        public int pricePerDay;
        public string? numberPlate;
    }
}

//Motorbike List as taken directly from program.cs during implementation

//Motorbikes
// //First Bike
// Motorbike b1 = new Motorbike();
// b1.make = "Harley Davidson";
// b1.model = "RoadGlide";
// b1.yearOfManufacture = 2023;
// b1.mileage = 25856;
// b1.pricePerDay = 200;
// b1.numberPlate = "HD23LOW";
// motorbikeDict.Add(b1.numberPlate, b1);
//Second Bike
// Motorbike b2 = new Motorbike();
// b2.make = "BMW";
// b2.model = "F900 GS";
// b2.yearOfManufacture = 2025;
// b2.mileage = 1298;
// b2.pricePerDay = 180;
// b2.numberPlate = "BM25SPD";
// motorbikeDict.Add(b2.numberPlate, b2);
//Third Bike
// Motorbike b3 = new Motorbike();
// b3.make = "BMW";
// b3.model = "R1300 GS Adventure";
// b3.yearOfManufacture = 2024;
// b3.mileage = 11092;
// b3.pricePerDay = 200;
// b3.numberPlate = "SP24LOR";
// motorbikeDict.Add(b3.numberPlate, b3);
// //Fourth Bike
// Motorbike b4 = new Motorbike();
// b4.make = "Honda";
// b4.model = "RoadGlide";
// b4.yearOfManufacture = 2019;
// b4.mileage = 28933;
// b4.pricePerDay = 200;
// b4.numberPlate = "HN19DAR";
// motorbikeDict.Add(b4.numberPlate, b4);
// //ADD MORE MOTORBIKES HERE
