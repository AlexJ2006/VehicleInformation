using System.Reflection;
using System.Drawing; 

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
            errorRedWarning();
            Console.WriteLine("Input INVALID. Please retry.");
            insertBreak();
        }

        public static void invaliInputDuringRental()
        {
            errorYellowWarning();
            Console.WriteLine("Sorry, this vehicle could not be found.");
            insertBreak();
        }

        public static void guestModeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ENTERING GUEST MODE...");
            Console.ResetColor();
        }

        public static void loggingInMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LOGGING YOU IN...");
            Console.ResetColor();
        }

        public static void newUserWelcomeMessage()
        {
            Console.WriteLine("WELCOME NEW USER");
        }

        public static void staffModeAlert()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************** USER ALERT ****************");
            Console.ResetColor();
            Console.WriteLine("To enter STAFF MODE please enter the following when prompted");
            Console.WriteLine("--staff staffUsername staffPassword");
            Console.WriteLine("ELSE");
            Console.WriteLine("Enter E to enter the guest/customer menus");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************** USER ALERT ****************");
            Console.ResetColor();
            Utilities.insertBreak();
        }

        public static void getAndShowVersion()
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";

            insertBreak();
            insertBreak();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"================ Version {version} ================");
            Console.ResetColor();
            insertBreak();
        }

        public static void welcomeUser()
        {
            Console.WriteLine("WELCOME to VRS");
            insertBreak();
        }

        public static void userSelectMenu()
        {
            Utilities.insertBreak();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Loading MAIN FUNCTION...");
            Console.ResetColor();
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

        public static void getUserCommand()
        {
            Console.WriteLine("To enter as STAFF or ADMIN. Please enter your credentials in the following format:. ");
            Utilities.insertBreak();
            Utilities.staffModeAlert();
            Console.WriteLine("OR");
            Utilities.insertBreak();
            Console.WriteLine("Press E to enter the main program.");
            Utilities.insertBreak();
            Console.Write("ENTER COMMAND: ");
            string enterStaff = Console.ReadLine()!;
            string[] staffArgs = enterStaff.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // if(enterStaff == "E")
            // {
                
            // }
        }

        public static void invalidPasswordEntry()
        {
            errorYellowWarning();
            Console.WriteLine("Your password MUST NOT exceed 16 characters");
        }

        public static void invalidUserIDEntry()
        {
            errorRedWarning();
            Console.WriteLine("Your USER ID MUST NOT exceed 5 characters and MUST only contain numbers");
        }

        public static void errorYellowWarning()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WARNING: ");
            Console.ResetColor();
        }

        public static void errorRedWarning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WARNING: ");
            Console.ResetColor();
        }

    }
}
