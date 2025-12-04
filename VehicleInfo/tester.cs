// public static void AdminFunction()
// {
//     while (true)
//     {
//         Console.WriteLine("Please select a function from the following");
//         Utilities.insertBreak();
//         Console.WriteLine("A) ADD staff member");
//         Utilities.insertBreak();
//         Console.WriteLine("R) REMOVE staff member");
//         Utilities.insertBreak();
//         Console.WriteLine("V) VIEW staff member list");
//         Utilities.insertBreak();
//         Console.WriteLine("G) GENERATE staff report");
//         Utilities.insertBreak();
//         Console.WriteLine("L) LOG OUT");
//         Console.Write("ENTER YOUR CHOICE:");
//         string adminFunctionChoice = Console.ReadLine() ?? "";

//         if (adminFunctionChoice.Equals("A", StringComparison.OrdinalIgnoreCase))
//         {
//            //They are asked to enter the staff ID 
//             Utilities.insertBreak();
//             Console.Write("STAFF ID: ");
//             string stringStaffID = Console.ReadLine() ?? "";
//             if (!int.TryParse(stringStaffID, out int staffID))
//             {
//                 //Exception handling here.
//                 //If the string provided cannot be converted to an integer.
//                 Utilities.errorYellowWarning(); //Provide a preset warning.                    Console.WriteLine($"Cannot convert '{stringStaffID}' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
//             }

//             //If they have met the requirements above with no errors.
//             Console.Write("FIRST NAME: "); //Provide the first name.
//             string firstName = Console.ReadLine() ?? ""; //Read the first name that has been inputted
//             Console.Write("LAST NAME: "); //Provide the last name.
//             string lastName = Console.ReadLine() ?? "";

//             //Then, with the details provided
//             //Create a new instance of the staff class
//             Staff newStaff = new Staff();
//             newStaff.SetID(staffID);
//             newStaff.SetFirstName(firstName);
//             newStaff.SetLastName(lastName);

//             //Then add these to the Binary File
//             StaffData.staffDict[staffID] = newStaff;
//             StaffData.SaveToBinary();
//             Console.WriteLine("STAFF ADDED");
//         }
//         else if (adminFunctionChoice.Equals("R", StringComparison.OrdinalIgnoreCase))
//         {
                
//             Console.WriteLine("You have selected to REMOVE a staff member, is this true?");
//             Console.Write("ENTER Y OR N: ");
//             string continueWithStaffRemoval = Console.ReadLine()!;
               
//             if (continueWithStaffRemoval.Equals("Y", StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("Please enter the following details of the staff member you wish to remove");

//                 Console.Write("Staff ID: ");
//                 string stringStaffID = Console.ReadLine()!;
//                 int staffID;

//                 try
//                 {
//                     staffID = Convert.ToInt32(stringStaffID);
//                 }
//                 catch (FormatException)
//                 {
//                     Utilities.errorYellowWarning();
//                     Console.WriteLine($"Cannot convert '{stringStaffID}' to a number. Please RETRY."); //Warning the user that the string they have entered cannot be converted to an integer.
//                 }

//                 Utilities.insertBreak();
//                 Console.Write("First Name: ");
//                 string firstName = Console.ReadLine()!;

//                 Utilities.insertBreak();
//                 Console.Write("Last Name: ");
//                 string lastName = Console.ReadLine()!;
                   
//                 AdminFunctions.RemoveStaff(staffID, firstName, lastName);
//             }
//         }
//         else if (adminFunctionChoice.Equals("V", StringComparison.OrdinalIgnoreCase))
//         {
//             AdminFunctions.ViewAllStaff(); 
//         }
//         else if(adminFunctionChoice.Equals("G", StringComparison.OrdinalIgnoreCase))
//         {
//             AdminFunctions.GenerateStaffReport();
//         }
//         else if(adminFunctionChoice.Equals("L", StringComparison.OrdinalIgnoreCase))
//         {
//             return;
//         }
//         else
//         {
//             Utilities.invalidInput();
//         }
//     }
// }
