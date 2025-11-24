using storeList;

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

                string lastName = args[2] ?? "";

                if (StaffData.staffDict.TryGetValue(id, out Staff? staff) &&
                    staff != null &&
                    !string.IsNullOrEmpty(staff.lastName) &&
                    staff.lastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"WELCOME STAFF MEMBER {staff.GetName()}");
                    staffMember();
                }
                else
                {
                    Console.WriteLine("ACCESS DENIED");
                }
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
            string staffMenuChoice = Console.ReadLine() ?? "";
            Utilities.insertBreak();

            if (staffMenuChoice.Equals("A", StringComparison.OrdinalIgnoreCase))
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
                string addVehicleType = Console.ReadLine() ?? "";
                Utilities.insertBreak();

                if (addVehicleType.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to ADD MULTIPLE CARS?: ");
                    string addMultipleCars = Console.ReadLine() ?? "";
                    Utilities.insertBreak();

                    if (addMultipleCars.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        addMultipleCars.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many cars would you like to add?: ");
                        string stringHowManyCars = Console.ReadLine() ?? "";
                        if (!int.TryParse(stringHowManyCars, out int intHowManyCars))
                        {
                            Utilities.errorYellowWarning();
                            Console.WriteLine($"Cannot convert '{stringHowManyCars}' to a number");
                            return;
                        }
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
                else if (addVehicleType.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to ADD MULTIPLE MOTORBIKES?: ");
                    string addMultipleMotorbikes = Console.ReadLine() ?? "";

                    if (addMultipleMotorbikes.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        addMultipleMotorbikes.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many motorbikes would you like to add?: ");
                        string stringHowManyMotorbikes = Console.ReadLine() ?? "";
                        if (!int.TryParse(stringHowManyMotorbikes, out int intHowManyMotorbikes))
                        {
                            Utilities.errorYellowWarning();
                            Console.WriteLine($"Cannot convert '{stringHowManyMotorbikes}' to a number");
                            return;
                        }

                        while (intHowManyMotorbikes > 0)
                        {
                            intHowManyMotorbikes--;
                            VehicleManagement.addMotorbike();
                        }
                    }
                    else
                    {
                        Utilities.insertBreak();
                        VehicleManagement.addMotorbike();
                    }
                }
                else if (addVehicleType.Equals("V", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to ADD MULTIPLE VANS?: ");
                    string addMultipleVans = Console.ReadLine() ?? "";

                    if (addMultipleVans.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        addMultipleVans.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many vans would you like to add?: ");
                        string stringHowManyVans = Console.ReadLine() ?? "";
                        if (!int.TryParse(stringHowManyVans, out int intHowManyVans))
                        {
                            Utilities.errorYellowWarning();
                            Console.WriteLine($"Cannot convert '{stringHowManyVans}' to a number");
                            return;
                        }

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
                    Utilities.invalidInput();
                    Console.WriteLine("WRONG SECTION");
                }
            }
            else if (staffMenuChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                //Remove Vehicle from list section
            }
            else if (staffMenuChoice.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The current list of stores will be displayed below: ");
                Console.WriteLine("The list will be automatically sorted, alphabetically");
                Utilities.insertBreak();

                StoreFunctions.storeListSort();
                StoreFunctions.storeListDisplay();

                Utilities.insertBreak();
                Console.WriteLine("Please select one of the following functions: ");
                Console.WriteLine("A) ADD STORE(S)");
                Console.WriteLine("R) REMOVE STORE(S)");
                Console.WriteLine("V) VIEW STORE LIST");
                Console.WriteLine("C) CLEAR STORE LIST");
                string decision = Console.ReadLine() ?? "";

                if (decision.Equals("A", StringComparison.OrdinalIgnoreCase))
                {
                    StoreFunctions.storeAdd();
                    Console.WriteLine("Would you like to add another store?: ");
                    string addMoreStores = Console.ReadLine() ?? "";

                    if (addMoreStores.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        StoreFunctions.storeAdd();
                    }
                    else
                    {
                        Console.WriteLine("You will now be logged out, THANK YOU.");
                    }
                }
                else if (decision.Equals("R", StringComparison.OrdinalIgnoreCase))
                {
                    StoreFunctions.storeRemove();
                    Console.WriteLine("Would you like to remove another store?: ");
                    string removeMoreStores = Console.ReadLine() ?? "";

                    if (removeMoreStores.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        StoreFunctions.storeRemove();
                    }
                    else
                    {
                        Console.WriteLine("You will now be logged out, THANK YOU.");
                    }
                }
                else if (decision.Equals("V", StringComparison.OrdinalIgnoreCase))
                {
                    string displayNumberOfItems = Console.ReadLine() ?? "";
                    if (!int.TryParse(displayNumberOfItems, out int intdisplayNumberOfItems))
                        intdisplayNumberOfItems = StoreInfo.stores.Count;

                    for (int i = 0; i < Math.Min(intdisplayNumberOfItems, StoreInfo.stores.Count); i++)
                    {
                        Console.WriteLine(StoreInfo.stores[i]);
                    }
                }
                else if (decision.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Are you sure you wish to CLEAR the STORE LIST? ");
                    Console.WriteLine("Y OR N");
                    Utilities.errorRedWarning();
                    Console.WriteLine("THIS ACTION CANNOT BE UNDONE");
                    string continueWithClearance = Console.ReadLine() ?? "";

                    if (continueWithClearance.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        StoreFunctions.storeListClear();
                    }
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
            string stringUserID = Console.ReadLine() ?? "";
            if (!int.TryParse(stringUserID, out int intUserID))
            {
                Utilities.errorYellowWarning();
                Console.WriteLine($"Cannot convert '{stringUserID}' to a number");
                return;
            }

            Utilities.insertBreak();
            Console.WriteLine("Please note, the password MUST NOT exceed the length of 16 characters.");
            Console.Write("Password:");
            string stringUserPassword = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.WriteLine("DoB: ");
            string stringDoB = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("Contact Number: ");
            string stringContactNumber = Console.ReadLine() ?? "";
            if (!int.TryParse(stringContactNumber, out int contactNumber))
            {
                Utilities.errorYellowWarning();
                Console.WriteLine($"Cannot convert '{stringContactNumber}' to a number");
                return;
            }

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

            Customer newCustomer = new Customer();
            newCustomer.SetUserID(intUserID);
            newCustomer.SetFirstName(firstName);
            newCustomer.SetLastName(lastName);
            newCustomer.SetDoB(stringDoB);
            newCustomer.SetContactNumber(contactNumber);
            newCustomer.SetPassword(stringUserPassword);

            CustomerData.customerDict[intUserID] = newCustomer;
            CustomerData.SaveToJson();
            Console.WriteLine("ACCOUNT CREATED");
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
            string adminFunctionChoice = Console.ReadLine() ?? "";

            if (adminFunctionChoice.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                Utilities.insertBreak();
                Console.Write("STAFF ID: ");
                string stringStaffID = Console.ReadLine() ?? "";
                if (!int.TryParse(stringStaffID, out int staffID))
                {
                    Utilities.errorYellowWarning();
                    Console.WriteLine($"Cannot convert '{stringStaffID}' to a number");
                    return;
                }

                Console.Write("FIRST NAME: ");
                string firstName = Console.ReadLine() ?? "";
                Console.Write("LAST NAME: ");
                string lastName = Console.ReadLine() ?? "";

                Staff newStaff = new Staff
                {
                    staffID = staffID,
                    firstName = firstName,
                    lastName = lastName
                };
                StaffData.staffDict[staffID] = newStaff;
                CarData.SaveToJson();
                Console.WriteLine("STAFF ADDED");
            }
            else if (adminFunctionChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                // Remove staff logic
            }
            else if (adminFunctionChoice.Equals("V", StringComparison.OrdinalIgnoreCase))
            {
                // View staff logic
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
//Using a HashSet for the userInformation is much faster than a list, you can find an item within the list much quicker. 
//The reason for using encapsulation is for futureproofing.
//Can't use that here as it means the entire field need to be unique, not only the password. 
//This can't happen as multiple users may have the same name or DoB for example.