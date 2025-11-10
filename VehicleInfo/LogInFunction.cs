using UserData;

namespace VehicleInfo
{
    public static class LogInFunction
    {
        public static void LogIn()
        {
            Utilities.insertBreak();
            Console.WriteLine("Do you currentl have an account?");
            Utilities.insertBreak();
            Console.WriteLine("Please enter: ");
            Utilities.insertBreak();
            Console.WriteLine("Y for YES");
            Console.WriteLine("OR");
            Console.Write("N for NO ");
            string userHasAnAccount = Console.ReadLine()!;
            
            if (userHasAnAccount == "Y" || userHasAnAccount == "y")
            {
                //Obtaining the user's details.
                Console.WriteLine("Please enter your credentials");
                Console.Write("USER ID: ");
                string userID = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("PASSWORD: ");
                string password = Console.ReadLine()!;

                if (UserDatabaseManager.ValidateUserLogIn(userID, password))
                {
                    //if the user can/has been logged in
                    Console.WriteLine("YOU HAVE BEEN LOGGED IN");
                }
                else
                {
                    //if the user can't be logged in 
                    Console.WriteLine("LOGIN UNSUCCESSFUL");
                    Console.WriteLine("The Program will now terminate. PLEASE RETRY.");
                    return;
                }
                //Complete the log in functions
            }
            else if (userHasAnAccount == "N" || userHasAnAccount == "n")
            {
                Console.Write("Would you like to CREATE an account?: ");
                string createAccount = Console.ReadLine()!;

                if (createAccount == "Y" || createAccount == "y")
                {
                    //The user creates their account here.
                    UserType.RegisterNewUser();
                }
                else if (createAccount == "N" || createAccount == "n")
                {
                    Console.Write("Would you like to continue as a GUEST?: ");
                    string continueAsGuest = Console.ReadLine()!;

                    if(continueAsGuest == "Y" || continueAsGuest == "y")
                    {
                        //Tell the user that they are not able to rent cars, they can only browse the available cars.
                        //The user continues as a guest.
                    }
                }
            }
        }
        
    }

}
