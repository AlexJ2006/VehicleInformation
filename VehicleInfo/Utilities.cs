using System.Reflection;

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
        public static void guestModeMessage()
        {
            Console.WriteLine("ENTERING GUEST MODE...");
        }
        public static void loggingInMessage()
        {
            Console.WriteLine("LOGGIN YOU IN...");
        }
        public static void newUserWelcomeMessage()
        {
            Console.WriteLine("WELCOME NEW USER");
        }
        public static void staffModeAlert()
        {
            Console.WriteLine("**************** USER ALERT ****************");
            Console.WriteLine("To enter STAFF MODE please enter the following when prompted");
            Console.WriteLine("--staff staffUsername staffPassword");
            Console.WriteLine("ELSE");
            Console.WriteLine("Enter E to enter the guest/customer menus");
            Console.WriteLine("**************** USER ALERT ****************");
        }
        public static void getAndShowVersion()
        {
            //Showing the user the version as per the "Version" tag within the VehicleInfo.csproj file.
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";

            insertBreak();
            //Displaying the Version.
            insertBreak();
            Console.WriteLine($" ================ Version {version} ================");
            insertBreak();
        }
        public static void welcomeUser()
        {
            Console.WriteLine("WELCOME to CRS");
            insertBreak();
            //The alert for the staff mode selection.
            Utilities.staffModeAlert();
        }
        public static void userSelectMenu()
        {
            insertBreak();
            Console.WriteLine("Please select one of the following choices:");
            insertBreak();
            Console.WriteLine("G) for GUEST");
            insertBreak();
            Console.WriteLine("C) to CREATE an ACCOUNT");
            insertBreak();
            Console.WriteLine("L) to LOG IN to an EXISTING ACCOUNT");
            insertBreak();
        }
    }
}
