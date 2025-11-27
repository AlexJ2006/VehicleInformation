using System;
using System.Linq;

namespace VehicleInfo
{
    //The log in function for the user
    public static class LogInFunction
    {
        public static void LogIn()
        {
            //Asking the user whether they currently have an account
            Utilities.insertBreak();
            Console.WriteLine("Do you currently have an account?");
            Utilities.insertBreak();
            Console.Write("Y OR N: ");
            string userHasAnAccount = Console.ReadLine()!;

            //If they have an account...
            if (userHasAnAccount.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Utilities.insertBreak();
                Console.WriteLine("Please enter your credentials"); //They are requested to log in using their credentials
                Utilities.insertBreak();
                Console.Write("USER ID: ");
                string inputID = Console.ReadLine()!;

                //Ensuring the user ID entered is numeric
                if (!int.TryParse(inputID, out int userID))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid user ID format.");
                    Console.ResetColor();
                    return; //Terminating if invalid
                }

                Utilities.insertBreak();
                Console.Write("PASSWORD: ");
                string password = Console.ReadLine()!;

                CustomerData.LoadFromBinary();

                //Checking the userID against the customer dictionary
                var user = CustomerData.customerDict.Values
                    .FirstOrDefault(c => c.GetUserID() == userID);

                if (user != null && user.GetPassword() == password) //If everything seems in order
                {
                    Console.ForegroundColor = ConsoleColor.Green; //Changing the text to green
                    Console.WriteLine("YOU HAVE BEEN LOGGED IN");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; //Changing the colour manually
                    Console.WriteLine("LOGIN UNSUCCESSFUL");
                    Console.WriteLine("The Program will now terminate. PLEASE RETRY."); //Warning the user that the program will terminate
                    Console.ResetColor();
                    return; //Returning, terminating the program
                }
            }
            //If they have selected that they do not have an account...
            else if (userHasAnAccount.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Utilities.insertBreak();
                Console.Write("Would you like to CREATE an account?: "); //They are asked if they wish to create an account now
                string createAccount = Console.ReadLine()!;

                if (createAccount.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If they would like to create an account
                {
                    UserType.RegisterNewUser(); //The system begins to register a new user using the pre-set function
                }
                else if (createAccount.Equals("N", StringComparison.OrdinalIgnoreCase)) //If they don't wish to create an account
                {
                    Console.Write("Would you like to continue as a GUEST?: "); //Would they like to continue as a guest?
                    string continueAsGuest = Console.ReadLine()!;

                    if (continueAsGuest.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If yes, they are switched to the guest logic/menu
                    {
                        VehicleManagement.guestMenu(); //Starting the guest menu
                    }
                }
            }
        }
    }
}
