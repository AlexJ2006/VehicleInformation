namespace VehicleInfo
{
    public static class LogInFunction
    {
        public static void LogIn()
        {
            Utilities.insertBreak();
            Console.WriteLine("Do you currently have an account?");
            Utilities.insertBreak();
            Console.Write("Y OR N: ");
            string userHasAnAccount = Console.ReadLine()!;

            if (userHasAnAccount == "Y" || userHasAnAccount == "y")
            {
                Utilities.insertBreak();
                Console.WriteLine("Please enter your credentials");
                Utilities.insertBreak();
                Console.Write("USER ID: ");
                string userID = Console.ReadLine()!;
                Utilities.insertBreak();
                Console.Write("PASSWORD: ");
                string password = Console.ReadLine()!;

                CustomerData.LoadFromBinary();
                var user = CustomerData.customerDict.Values
                    .FirstOrDefault(c => c.GetUserID() == userID);

                if (user != null && user.GetPassword() == password)
                {
                    Console.WriteLine("YOU HAVE BEEN LOGGED IN");
                }
                else
                {
                    Console.WriteLine("LOGIN UNSUCCESSFUL");
                    Console.WriteLine("The Program will now terminate. PLEASE RETRY.");
                    return;
                }
            }
            else if (userHasAnAccount == "N" || userHasAnAccount == "n")
            {
                Utilities.insertBreak();
                Console.Write("Would you like to CREATE an account?: ");
                string createAccount = Console.ReadLine()!;

                if (createAccount == "Y" || createAccount == "y")
                {
                    UserType.RegisterNewUser();
                }
                else if (createAccount == "N" || createAccount == "n")
                {
                    Console.Write("Would you like to continue as a GUEST?: ");
                    string continueAsGuest = Console.ReadLine()!;

                    if (continueAsGuest == "Y" || continueAsGuest == "y")
                    {
                        // Continue as guest logic here
                    }
                }
            }
        }
    }
}
