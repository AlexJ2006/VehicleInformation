using CarInfo;

namespace VehicleInfo
{
    public static class UserType
    {
        public static void staffArgsMenu(string[] args)
        {

            Utilities.getUserCommand();
            if (args.Length == 3 && args[0].Equals("--staff", StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(args[1], out int id))
                {
                    Console.WriteLine("Invalid staff ID format.");
                    return;
                }
                string lastName = args[2];

                if (StaffData.staffDict.TryGetValue(id, out Staff staff) &&
                    staff.lastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"WELCOME STAFF MEMBER {staff.GetName()}");
                    UserType.staffMember();
                }
                else
                {
                    Console.WriteLine("ACCESS DENIED");
                }
                return;
            }
        }

        public static void staffMember()
        {
            Utilities.insertBreak();
            Console.WriteLine("WELCOME STAFF");
            Utilities.insertBreak();
            Console.WriteLine("Which of the following functions would you like to perform?");
            Utilities.insertBreak();
            Console.WriteLine("A) ADD VEHICLES");
            Utilities.insertBreak();
            Console.WriteLine("R) REMOVE VEHICLES");
            Utilities.insertBreak();
            Console.WriteLine("E) EDIT STORE LIST");
            Utilities.insertBreak();
            Console.Write("Please Enter Your Choice: ");
            string? staffMenuChoice = Console.ReadLine();
            Utilities.insertBreak();

            if (staffMenuChoice == "A" || staffMenuChoice == "a")
            {
                Console.WriteLine("Would you like to add");
                Utilities.insertBreak();
                Console.WriteLine("C) CAR");
                Utilities.insertBreak();
                Console.WriteLine("M) MOTORBIKE");
                Utilities.insertBreak();
                Console.WriteLine("OR");
                Utilities.insertBreak();
                Console.WriteLine("V) VAN");
                Utilities.insertBreak();
                Console.Write("PLEASE ENTER YOUR CHOICE: ");
                string addVehicleType = Console.ReadLine()!;
                Utilities.insertBreak();

                if (addVehicleType == "C" || addVehicleType == "c")
                {
                    Console.Write("Would you like to ADD MULTIPLE CARS?: ");
                    string addMultipleCars = Console.ReadLine()!;
                    Utilities.insertBreak();

                    if (addMultipleCars == "Yes" || addMultipleCars == "yes" || addMultipleCars == "Y" || addMultipleCars == "y")
                    {
                        Console.Write("How many cars would you like to add?: ");
                        string stringHowManyCars = Console.ReadLine()!;
                        int intHowManyCars = Convert.ToInt32(stringHowManyCars);
                        Utilities.insertBreak();

                        while (intHowManyCars > 0)
                        {
                            intHowManyCars--;
                            VehicleManagement.addCar();

                        }
                    }
                    else
                    {
                        VehicleManagement.addCar();
                    }
                }
                else if (addVehicleType == "M" || addVehicleType == "m")
                {
                    Console.Write("Would you like to ADD MULTIPLE MOTORBIKES?: ");
                    string addMultipleMotorbikes = Console.ReadLine()!;

                    if (addMultipleMotorbikes == "Yes" || addMultipleMotorbikes == "yes" || addMultipleMotorbikes == "Y" || addMultipleMotorbikes == "y")
                    {
                        Console.Write("How many motorbikes would you like to add?: ");
                        string stringHowManyMotorbikes = Console.ReadLine()!;
                        int intHowManyMotorbikes = Convert.ToInt32(stringHowManyMotorbikes);

                        while (intHowManyMotorbikes > 0)
                        {
                            intHowManyMotorbikes--;
                            VehicleManagement.addMotorbike();
                        }
                    }
                    else
                    {
                        //One instance of the Add Motorbike class occurs rather than multiple
                        Utilities.insertBreak();

                        VehicleManagement.addMotorbike();
                    }
                }
                else if (addVehicleType == "V" || addVehicleType == "v")
                {
                    Console.Write("Would you like to ADD MULTIPLE VANS?: ");
                    string addMultipleVans = Console.ReadLine()!;

                    if (addMultipleVans == "Yes" || addMultipleVans == "yes" || addMultipleVans == "Y" || addMultipleVans == "y")
                    {
                        Console.Write("How many vans would you like to add?: ");
                        string stringHowManyVans = Console.ReadLine()!;
                        int intHowManyVans = Convert.ToInt32(stringHowManyVans);

                        while (intHowManyVans > 0)
                        {
                            intHowManyVans--;
                            VehicleManagement.addVan();
                        }
                    }
                    else
                    {
                        Utilities.insertBreak();
                        VehicleManagement.addVan();
                    }
                }
                else
                {
                    //Provide Error Message
                    Utilities.invalidInput();
                    Console.WriteLine("WRONG SECTION");
                }
            }
            else if (staffMenuChoice == "R" || staffMenuChoice == "r")
            {
                //Remove Vehicle from list section
            }
            else if (staffMenuChoice == "E" || staffMenuChoice == "e")
            {
                Console.WriteLine("The current list of stores will be displayed below: ");
                Utilities.insertBreak();

                StoreFunctions.storeListDisplay();

                Utilities.insertBreak();
                Console.Write("Would you like to Add a new store to the list?: ");
                string decision = Console.ReadLine()!;
                if (decision == "Yes" || decision == "yes")
                {
                    StoreFunctions.storeAdd();
                    Console.WriteLine("Would you like to add another store?: ");
                    string addMoreStores = Console.ReadLine()!;

                    if (addMoreStores == "Yes" || addMoreStores == "yes")
                    {
                        StoreFunctions.storeAdd();
                    }
                    else
                    {
                        Console.WriteLine("You will now be logged out, THANK YOU.");
                    }
                }
                else if (decision == "No" || decision == "no")
                {
                    Console.WriteLine("Would you like to remove a store from the list?: ");
                    string removeStore = Console.ReadLine()!;

                    if (removeStore == "Yes" || removeStore == "yes")
                    {
                        Console.WriteLine("Please enter the name of the store you wish to remove from the list");
                        Console.WriteLine("OR");
                        Console.WriteLine("Press V to view the list");
                        Console.Write("Enter Your Choice: ");
                        string choice = Console.ReadLine()!;

                        if (choice == "V" || choice == "v")
                        {
                            StoreFunctions.storeListDisplay();
                        }
                        else
                        {
                            Utilities.invalidInput();
                        }
                    }
                }
                else
                {
                    //Provide Error Message
                    Utilities.invalidInput();
                    Console.WriteLine("WRONG SECTION");
                }
            }
        }
        public static void RegisterNewUser()
        {
            Utilities.insertBreak();
            Console.WriteLine("Please Complete the following Steps to create your account");
            Utilities.insertBreak();
            Console.WriteLine("Please note, the USER ID must ONLY contain NUMBERS and must not contain more than 5 characters");
            Utilities.insertBreak();
            Console.Write("UserID: ");
            string stringUserID = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.WriteLine("Please note, the password MUST NOT exceed the length of 16 characters.");
            Console.Write("Password:");
            string stringUserPassword = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("First Name: ");
            string firstName = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.WriteLine("DoB: ");
            string stringDoB = Console.ReadLine()!;
            Utilities.insertBreak();
            Console.Write("Contact Number: ");
            string stringContactNumber = Console.ReadLine()!;
            int contactNumber = Convert.ToInt32(stringContactNumber);

            if (stringUserID.Length > 5)
            {
                Utilities.invalidUserIDEntry();
                return;
            }
            else if (stringUserPassword.Length > 16)
            {
                Utilities.invalidPasswordEntry();
                return;
            }
            else
            {
                UserData.UserDatabaseManager.RegisteredUser(stringUserID, stringUserPassword, firstName, lastName, stringDoB, stringContactNumber);
            }            
        }
        public static void AdminFunction()
        {
            Console.WriteLine("Please select a function from the following");
            Utilities.insertBreak();
            Console.WriteLine("A) ADD staff member");
            Utilities.insertBreak();
            Console.WriteLine("R) REMOVE staff member");
            Utilities.insertBreak();
            Console.WriteLine("V) VIEW staff member lsit");
            Utilities.insertBreak();
            Console.Write("ENTER YOUR CHOICE:");
            string adminFunctionChoice = Console.ReadLine()!;

            if (adminFunctionChoice == "A" || adminFunctionChoice == "a")
            {
                Utilities.insertBreak();
                Console.Write("STAFF ID: ");
                string stringStaffID = Console.ReadLine()!;
                int staffID = Convert.ToInt32(stringStaffID);
                Console.Write("FIRST NAME: ");
                string firstName = Console.ReadLine()!;
                Console.Write("LAST NAME: ");
                string lastName = Console.ReadLine()!;

                Staff newStaff = new Staff
                {
                    staffID = staffID,
                    firstName = firstName,
                    lastName = lastName
                };
                //Adding the car to the dictionary.
                StaffData.staffDict.Add(newStaff.staffID, newStaff);

                //Saving the Cars to the JSON file.
                CarData.SaveToJson();
                Console.WriteLine("CAR ADDED");

            }
            else if (adminFunctionChoice == "R" || adminFunctionChoice == "r")
            {

            }
            else if (adminFunctionChoice == "V" || adminFunctionChoice == "v")
            {

            }
            else
            {
                Utilities.invalidInput();
            }
        }

        internal static void staffArgsMenu(object staffArgs)
        {
            throw new NotImplementedException();
        }
    }
}

