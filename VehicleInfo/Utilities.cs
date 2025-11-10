namespace VehicleInfo
{
    public static class Utilities
    {
        public static void insertBreak()
        {
            Console.WriteLine("");
        }
        public static void invalidInput()
        {
            Console.WriteLine("Input INVALID. Please retry.");
        }
        public static void invaliInputDuringRental()
        {
            Console.WriteLine("Sorry, this vehicle could not be found.");
        }
    }
}
