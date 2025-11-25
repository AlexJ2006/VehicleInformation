using storeList;

namespace VehicleInfo
{
    public static class UserType
    {
        //Getting the args from the user that allow them to LOG IN as STAFF or ADMIN. 
        public static void staffArgsMenu(string[] args)
        {
            //Getting the command from the user.
            Utilities.getUserCommand();

            //If the arguments provided by the user (through getUserCommand, found in the utilities folder), match the necessary criteria.
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
                    //If the arguments provided by the user do not meet the requirements above.
                    Console.WriteLine("ACCESS DENIED"); //They will not have access to the system under STAFF or ADMIN.
                }
            }
        }

        //If the user logs in as a staff member
        public static void staffMember()
        {
            //They are provided with this staff menu
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

            //If they want to Add a VEHICLE
            if (staffMenuChoice.Equals("A", StringComparison.OrdinalIgnoreCase)) //Specifying that the case doesn't matter. Error handling here.
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

                //If they select that they want to ADD a CAR.
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

                        //Add cars until the number of cars that have been specified by the user, meets 0
                        while (intHowManyCars > 0)
                        {
                            //Taking 1 from the number that the user has selected, each time the loop runs.
                            intHowManyCars--;
                            VehicleManagement.addCar(); //Add Car
                        }
                    }
                    else
                    {
                        //If the user did not want to add multiple cars
                        Utilities.insertBreak(); //Adding a break to enhance the UX (improve design)
                        VehicleManagement.addCar(); //Just run the function once (for one car)
                    }
                }
                //Else, if the user selects M to add a Motorcycle
                else if (addVehicleType.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to ADD MULTIPLE MOTORBIKES?: ");
                    string addMultipleMotorbikes = Console.ReadLine() ?? "";

                    if (addMultipleMotorbikes.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        addMultipleMotorbikes.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        //The user selects the number of motorcycles they wish to add.
                        Console.Write("How many motorbikes would you like to add?: ");
                        string stringHowManyMotorbikes = Console.ReadLine() ?? "";
                        if (!int.TryParse(stringHowManyMotorbikes, out int intHowManyMotorbikes))
                        {
                            Utilities.errorYellowWarning();
                            Console.WriteLine($"Cannot convert '{stringHowManyMotorbikes}' to a number");
                            return;
                        }

                        //Same logic as for the CAR section here.
                        while (intHowManyMotorbikes > 0)
                        {
                            intHowManyMotorbikes--;
                            VehicleManagement.addMotorbike();
                        }
                    }
                    else
                    {
                        //If they don't wish to add multiple cars...
                        Utilities.insertBreak();
                        VehicleManagement.addMotorbike();
                    }
                }
                //Repeating the same logic for VANS as for CARS and MOTORCYCLES
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
                        //If they wish to add multiple vans...
                        while (intHowManyVans > 0)
                        {
                            intHowManyVans--;
                            VehicleManagement.addVan();
                        }
                    }
                    else
                    {
                        //For the addition of just one van
                        Utilities.insertBreak();
                        VehicleManagement.addVan();
                    }
                }
                else
                {
                    //Else, if the user has not selected one of the options provided.
                    //THey are provided with a simple error message.
                    Utilities.invalidInput();
                    Console.WriteLine("WRONG SECTION");
                }
            }
            //If, in the first menu, the user selects to REMOVE a vehicle from the list.
            THIS NEEDS TO BE ADDED

            else if (staffMenuChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                //Remove Vehicle from list section
            }
            //else, if the user has selected to EDIT the STORE LIST
            else if (staffMenuChoice.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("The current list of stores will be displayed below: ");
                Console.WriteLine("The list will be automatically sorted, alphabetically");
                Utilities.insertBreak();

                //Displaying the store list
                StoreFunctions.storeListSort(); //Sorting the store list
                StoreFunctions.storeListDisplay(); //Displaying the sorted store list

                //Providing them with another menu, asking how they wish to manipulate the storel list
                Utilities.insertBreak();
                Console.WriteLine("Please select one of the following functions: ");
                Console.WriteLine("A) ADD STORE(S)");
                Console.WriteLine("R) REMOVE STORE(S)");
                Console.WriteLine("V) VIEW STORE LIST");
                Console.WriteLine("C) CLEAR STORE LIST");
                string decision = Console.ReadLine() ?? "";

                //If they wish to add a store
                if (decision.Equals("A", StringComparison.OrdinalIgnoreCase))
                {
                    StoreFunctions.storeAdd(); //Running the storeAdd function (to add a store)
                    Console.WriteLine("Would you like to add another store?: "); //Asking if they wish to add another store
                    string addMoreStores = Console.ReadLine() ?? "";
                    
                    //If so...
                    if (addMoreStores.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        //They can add another store here
                        StoreFunctions.storeAdd();
                    }
                    else
                    {
                        Console.WriteLine("You will now be logged out, THANK YOU.");
                    }
                }
                //If they wish to remove a store from the list
                else if (decision.Equals("R", StringComparison.OrdinalIgnoreCase))
                {
                    StoreFunctions.storeRemove(); //Remove store function (from the storeFunctions file)
                    Console.WriteLine("Would you like to remove another store?: "); //Would they like to remove another store?
                    string removeMoreStores = Console.ReadLine() ?? "";

                    if (removeMoreStores.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        //Remove another store
                        StoreFunctions.storeRemove();
                    }
                    else
                    {
                        //If not, they will be logged out. 
                        Console.WriteLine("You will now be logged out, THANK YOU.");
                    }
                }
                //Else, if they simply wish to view the store list
                else if (decision.Equals("V", StringComparison.OrdinalIgnoreCase))
                {
                    //Asking how many items they wish to view from the list.
                    string displayNumberOfItems = Console.ReadLine() ?? "";
                    if (!int.TryParse(displayNumberOfItems, out int intdisplayNumberOfItems))
                        intdisplayNumberOfItems = StoreInfo.stores.Count;

                    for (int i = 0; i < Math.Min(intdisplayNumberOfItems, StoreInfo.stores.Count); i++)
                    {
                        Console.WriteLine(StoreInfo.stores[i]);
                    }
                }
                //Clearing the store List
                else if (decision.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    //ASking if they are SURE they wish to clear the list.
                    Console.WriteLine("Are you sure you wish to CLEAR the STORE LIST? ");
                    Console.WriteLine("Y OR N");
                    Utilities.errorRedWarning();
                    Console.WriteLine("THIS ACTION CANNOT BE UNDONE"); //Warning them that this cannot be undone.
                    string continueWithClearance = Console.ReadLine() ?? "";

                    //If they still wish to continue
                    if (continueWithClearance.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        //Clearing the storeList
                        StoreFunctions.storeListClear();
                    }
                    else //If the user does not want to clear the store list
                    {
                        //Letting the user know that the store list has not been cleared (as per their request)
                        Console.WriteLine("Okay, the store list has not been cleared.");
                        Console.WriteLine("You will now be LOGGED OUT.");
                    }
                }
            }
        }

        //Registering the new user.
        public static void RegisterNewUser()
        {
            //Providing the user with information about specific requirements for creating their Password and UserID.
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
            //If the UserID that teh user has provided has an invalid length (larger than 5 characters)
            if (stringUserID.Length > 5)
            {
                //Provide error (preset within the Utilities file)
                Utilities.invalidUserIDEntry();
                return;
            }
            //If the password has a length that exceeds the maximum limit (16 characters)
            else if (stringUserPassword.Length > 16)
            {
                //Provide this preset error message (from utiltities again)
                Utilities.invalidPasswordEntry();
                return;
            }

            //If there aren't any errors found, create a new instance of the customer class.
            Customer newCustomer = new Customer();
            newCustomer.SetUserID(intUserID);
            newCustomer.SetFirstName(firstName);
            newCustomer.SetLastName(lastName);
            newCustomer.SetDoB(stringDoB);
            newCustomer.SetContactNumber(contactNumber);
            newCustomer.SetPassword(stringUserPassword);

            //Then, write the customers' information to the JSON FILE.
            WILL NEED TO BE CHANGED TO BINARY FILE

            CustomerData.customerDict[intUserID] = newCustomer;
            CustomerData.SaveToJson();
            Console.WriteLine("ACCOUNT CREATED");
        }

        //If the user logs in as a member of admin staff
        public static void AdminFunction()
        {
            //They are asked to select a function to perform.
            //Using a simple, user friendly menu layout.
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

            //If they wish to add a member of staff.
            if (adminFunctionChoice.Equals("A", StringComparison.OrdinalIgnoreCase))
            {   
                //They are asked to enter the staff ID 
                Utilities.insertBreak();
                Console.Write("STAFF ID: ");
                string stringStaffID = Console.ReadLine() ?? "";
                if (!int.TryParse(stringStaffID, out int staffID))
                {
                    //Exception handling here.
                    //If the string provided cannot be converted to an integer.
                    Utilities.errorYellowWarning(); //Provide a preset warning.
                    Console.WriteLine($"Cannot convert '{stringStaffID}' to a number");
                    return;
                }

                //If they have met the requirements above with no errors.
                Console.Write("FIRST NAME: "); //Provide the first name.
                string firstName = Console.ReadLine() ?? ""; //Read the first name that has been inputted (with ??"" before ; to show that the value cannot be null)
                Console.Write("LAST NAME: "); //Provide the last name.
                string lastName = Console.ReadLine() ?? "";

                //Then, with the details provided
                //Create a new instance of the staff class
                Staff newStaff = new Staff
                {
                    //And take the following sections
                    staffID = staffID,
                    firstName = firstName,
                    lastName = lastName
                };
                //Then add these to the JSON file.
                THIS NEEDS TO BE BINARY TOO

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
        COULD REMOVE NOW?
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