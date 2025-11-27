
namespace VehicleInfo
{
    //Setting up the vehicle base class
    public class Vehicle
    {
        private string? make;

        private string? model;

        private int yearOfManufacture;

        private int mileage;

        private int pricePerDay;

        private string? numberPlate;

        //Setting the getters and setters so the program can access all the necessary data as it is private otherwise
        public string? GetMake() => make;
        public string? GetModel() => model;
        public int GetYearOfManufacture() => yearOfManufacture;
        public int GetMileage() => mileage;
        public int GetPricePerDay() => pricePerDay;
        public string? GetNumberPlate() => numberPlate;

        public void SetMake(string make) => this.make = make;
        public void SetModel(string model) => this.model = model;
        public void SetYearOfManufacture(int year) => yearOfManufacture = year;
        public void SetMileage(int mileage) => this.mileage = mileage;
        public void SetPricePerDay(int price) => pricePerDay = price;
        public void SetNumberPlate(string plate) => numberPlate = plate;

        //Specifying what is actually included within the vehicle base class (everything needed for the vehicles apart from category)
        //This is because the motorcycle doesn't use category as a field, therefore I thought it would be better to just add category where needed
        public Vehicle(string make, string model, int yearOfManufacture,
                       int mileage, int pricePerDay, string numberPlate)
        {
            this.make = make;
            this.model = model;
            this.yearOfManufacture = yearOfManufacture;
            this.mileage = mileage;
            this.pricePerDay = pricePerDay;
            this.numberPlate = numberPlate;
        }

        //Creating an instance of the vehicle class
        public Vehicle() { }

        //Saving the vehicle to the Binary file (writing)
        public virtual void SaveBinary(BinaryWriter bw)
        {
            bw.Write(make ?? "");
            bw.Write(model ?? "");
            bw.Write(yearOfManufacture);
            bw.Write(mileage);
            bw.Write(pricePerDay);
            bw.Write(numberPlate ?? "");
        }
        //Loading the vehicle from the binary file (reading)
        public virtual void LoadBinary(BinaryReader br)
        {
            make = br.ReadString();
            model = br.ReadString();
            yearOfManufacture = br.ReadInt32();
            mileage = br.ReadInt32();
            pricePerDay = br.ReadInt32();
            numberPlate = br.ReadString();
        }
    }
}
