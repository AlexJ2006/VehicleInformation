using storeList;
namespace VehicleInfo
{
    public static class UserType
    {
        //Getting the args from the user that allow them to LOG IN as STAFF or ADMIN. 
        public static void staffArgsMenu()
        {
            // Load staff data from binary before accessing dictionary
            StaffData.LoadFromBinary();

            string[] args = Utilities.getUserCommand();

            //If the user wishes to enter the normal menu/mode
            if (args.Length == 1 && args[0].Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                //Displaying a message to the user from utilities.
                Utilities.nonStaffMenuMessage();
                return;
            }

            //If the user has attempted to log in as a member of staff 
            if (args.Length == 3 && args[0].Equals("--staff", StringComparison.OrdinalIgnoreCase))
            {
                //ensuring that the first argument (second but it's first as they begin at 0)
                //Can be converted to an integer.
                if (!int.TryParse(args[1], out int id))
                {
                    //If not...
                    Console.WriteLine("Invalid staff ID format."); //This error message will be shown
                    return;
                }
               
                string lastName = args[2]; //The second (third) argument should be the surname of the staff member

                if (StaffData.staffDict.TryGetValue(id, out Staff? staff) &&
                    staff.GetLastName().Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    //If the id and surname are matching within the staff Dictionary...
                {
                    //The staff member is logged in.
                    Console.WriteLine($"WELCOME STAFF MEMBER {staff.GetName()}");
                    staffMember();
                    return;
                }

                //Else, if all of these fail, the following message is displayed.
                Console.WriteLine("ACCESS DENIED");
                return;
            }

            // If the user wishes to log in as a member of admin staff...
            if (args.Length == 3 && args[0].Equals("--admin", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Admin detected (not implemented yet).");
                return;
            }

            Console.WriteLine("Invalid command.");
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
            else if (staffMenuChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Would you like to remove?");
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
                string removeVehicleType = Console.ReadLine() ?? "";
                Utilities.insertBreak();
               
                if (removeVehicleType.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to REMOVE MULTIPLE CARS?: ");
                    string removeMultipleCars = Console.ReadLine() ?? "";
                    Utilities.insertBreak();

                    if (removeMultipleCars.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        removeMultipleCars.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many cars would you like to remove?: ");
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

                            Console.Write("Enter the car make to remove: ");
                            string CarMake = Console.ReadLine() ?? "";

                            Console.Write("Enter the car model to remove: ");
                            string CarModel = Console.ReadLine() ?? "";

                            VehicleManagement.removeCar(CarMake, CarModel);
                        }
                    }
                    else
                    {
                        Utilities.insertBreak();

                        Console.Write("Enter the car make to remove: ");
                        string CarMake = Console.ReadLine() ?? "";

                        Console.Write("Enter the car model to remove: ");
                        string CarModel = Console.ReadLine() ?? "";

                        VehicleManagement.removeCar(CarMake, CarModel);
                    }
                }
                //Else, if the user selects M to remove a Motorcycle
                else if (removeVehicleType.Equals("M", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to REMOVE MULTIPLE MOTORBIKES?: ");
                    string removeMultipleMotorbikes = Console.ReadLine() ?? "";

                    if (removeMultipleMotorbikes.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        removeMultipleMotorbikes.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many motorbikes would you like to remove?: ");
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

                            Console.Write("Enter the motorbike make to remove: ");
                            string MotorbikeMake = Console.ReadLine() ?? "";

                            Console.Write("Enter the motorbike model to remove: ");
                            string MotorbikeModel = Console.ReadLine() ?? "";

                            VehicleManagement.removeMotorbike(MotorbikeMake, MotorbikeModel);
                        }
                    }
                    else
                    {
                        Utilities.insertBreak();

                        Console.Write("Enter the motorbike make to remove: ");
                        string MotorbikekMake = Console.ReadLine() ?? "";

                        Console.Write("Enter the motorbike model to remove: ");
                        string MotorbikeModel = Console.ReadLine() ?? "";

                        VehicleManagement.removeMotorbike(MotorbikekMake, MotorbikeModel);
                    }
                }
                //Repeating the same logic for VANS as for CARS and MOTORCYCLES
               else if (removeVehicleType.Equals("V", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Would you like to REMOVE MULTIPLE VANS?: ");
                    string removeMultipleVans = Console.ReadLine() ?? "";

                    if (removeMultipleVans.Equals("Yes", StringComparison.OrdinalIgnoreCase) ||
                        removeMultipleVans.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("How many vans would you like to remove?: ");
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

                            Console.Write("Enter van make to remove: ");
                            string VanMake = Console.ReadLine() ?? "";

                            Console.Write("Enter van model to remove: ");
                            string VanModel = Console.ReadLine() ?? "";

                            VehicleManagement.removeVan(VanMake, VanModel);
                        }
                    }
                    else
                    {
                        Utilities.insertBreak();

                        Console.Write("Enter van make to remove: ");
                        string VanMake = Console.ReadLine() ?? "";

                        Console.Write("Enter van model to remove: ");
                        string VanModel = Console.ReadLine() ?? "";

                        VehicleManagement.removeVan(VanMake, VanModel);
                    }
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
            else
            {
                //Else, if the user has not selected one of the options provided.
                //THey are provided with a simple error message.
                Utilities.invalidInput();
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
            Console.Write("Password: ");
            string stringUserPassword = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? "";
            Utilities.insertBreak();
            Console.Write("DoB: ");
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
            //If the UserID that the user has provided has an invalid length (larger than 5 characters)
            if (stringUserID.Length > 5)
            {
                //Provide error (preset within the Utilities file)
                Utilities.invalidUserIDEntry();
                return;
            }
            //If the password has a length that exceeds the maximum limit (16 characters)
            else if (stringUserPassword.Length > 16)
            {
                //Provide this preset error message (from utilities again)
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

            //Then, write the customers' information to the Binary File.
            CustomerData.customerDict[intUserID] = newCustomer;
            CustomerData.SaveToBinary();
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
            Console.WriteLine("V) VIEW staff member list");
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
                string firstName = Console.ReadLine() ?? ""; //Read the first name that has been inputted
                Console.Write("LAST NAME: "); //Provide the last name.
                string lastName = Console.ReadLine() ?? "";

                //Then, with the details provided
                //Create a new instance of the staff class
                Staff newStaff = new Staff();
                newStaff.SetID(staffID);
                newStaff.SetFirstName(firstName);
                newStaff.SetLastName(lastName);

                //Then add these to the Binary File
                StaffData.staffDict[staffID] = newStaff;
                StaffData.SaveToBinary();
                Console.WriteLine("STAFF ADDED");
            }
            else if (adminFunctionChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                // Remove staff logic (not implemented yet)
            }
            else if (adminFunctionChoice.Equals("V", StringComparison.OrdinalIgnoreCase))
            {
                // View staff logic (not implemented yet)
            }
            else
            {
                Utilities.invalidInput();
            }
        }
        internal static void staffArgsMenu(object staffArgs)
        {
           
        }    
    }
}
//Using a HashSet for the userInformation is much faster than a list, you can find an item within the list much quicker. 
//The reason for using encapsulation is for futureproofing.
//Can't use that here as it means the entire field need to be unique, not only the password. 
//This can't happen as multiple users may have the same name or DoB for example.