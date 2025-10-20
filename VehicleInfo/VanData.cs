using System.Collections.Generic;

namespace VanInfo
{
    public static class VanData
    {
        public static Dictionary<string, Van> vanDict = new Dictionary<string, Van>();
        static VanData()
        {
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

            //ADD MORE MOTORBIKES HERE
            //AGAIN, ALL THE BIKES ABOVE HAVE BEEN IMPLEMENTED MANUALLY FOR TESTING PURPOSES
        }

    }

    public class Van
    {
        public string? make;
        public string? model;
        public int yearOfManufacture;
        public int mileage;
        public string? category;
        public int pricePerDay;
        public string? numberPlate;
    }
}

//VanList as taken directly from program.cs during implementation
//Vans

//First Van
// Van v1 = new Van();
// v1.make = "Mercedes";
// v1.model = "Sprinter";
// v1.yearOfManufacture = 2019;
// v1.mileage = 125927;
// v1.category = "Large";
// v1.pricePerDay = 200;
// v1.numberPlate = "MD69SPR";
// vanDict.Add(v1.numberPlate, v1);
// //Second Van
// Van v2 = new Van();
// v2.make = "Volkswagen";
// v2.model = "Caddy";
// v2.yearOfManufacture = 2023;
// v2.mileage = 56929;
// v2.category = "Small";
// v2.pricePerDay = 200;
// v2.numberPlate = "VW23MDS";
// vanDict.Add(v2.numberPlate, v2);
// //Third Van
// Van v3 = new Van();
// v3.make = "Ford";
// v3.model = "Transit";
// v3.yearOfManufacture = 2020;
// v3.mileage = 84562;
// v3.category = "Small";
// v3.pricePerDay = 180;
// v3.numberPlate = "BM28JHS";
// vanDict.Add(v3.numberPlate, v3);
// //Fourth Van
// Van v4 = new Van();
// v4.make = "Renault";
// v4.model = "Kangoo";
// v4.yearOfManufacture = 2023;
// v4.mileage = 98233;
// v4.category = "Small";
// v4.pricePerDay = 185;
// v4.numberPlate = "JD82DSK";
// vanDict.Add(v4.numberPlate, v4);
//ADD MORE VANS HERE