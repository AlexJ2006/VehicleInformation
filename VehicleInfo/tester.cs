//  public static void storeAdd()
//         {
//             StoreInfo.LoadStores(); //Ensure the latest stores are loaded

//             var stores = StoreInfo.Stores; //Setting the variable as the storelist

//             Console.Write("Please enter the name of the store you wish to ADD: "); //Asking them to enter the name of the store they wish to add
//             string addStoreName = Console.ReadLine()!;

//             if (!stores.Contains(addStoreName)) //If the store list doesn't contain the name that they have provided
//             {
//                 stores.Add(addStoreName); //The store is added to the list
//                 StoreInfo.SaveStores();
//                 Console.ForegroundColor = ConsoleColor.Green; //Manually changing the colour to green
//                 Console.WriteLine("STORE ADDED, thank you."); //Letting the user know that the store has been added
//                 Console.ResetColor();
//                 Utilities.insertBreak();
//                 Console.WriteLine("Would you like to view the list?");
//                 Console.Write("Y OR N: ");
//                 string viewList = Console.ReadLine()!;

//                 if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If they have selected yes
//                 {
//                     storeListDisplay(); //Displaying the store list
//                 }
//                 else //If not...
//                 {
//                     Console.ForegroundColor = ConsoleColor.Green; //Changing the colour to green, manually again.
//                     Utilities.insertBreak();
//                     Console.WriteLine("Process complete. Thank you."); //Letting them know that the process is complete
//                     Console.ResetColor();
//                 }

//                 return;
//             }
//             else //If the store already exists within the list...
//             {
//                 Utilities.errorRedWarning(); //Displays WARNING: in red
//                 Console.WriteLine("This Store Already exists within the list"); //Giving the user a warning that the store already exists 

//                 Utilities.insertBreak();
//                 Console.WriteLine("Would you like to view the list?"); //Asking the user if they wish to view the list
//                 Utilities.insertBreak();
//                 Console.Write("Y OR N: ");
//                 string viewList = Console.ReadLine()!;
 
//                 if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If yes...
//                 {
//                     storeListDisplay(); //Displaying the list
//                 }
//                 else //If anything else
//                 {
//                     Console.ForegroundColor = ConsoleColor.Red; //Changing the colour to red
//                     Console.WriteLine("Please RETRY.");
//                     Console.ResetColor();
//                 }

//                 return;
//             }
//         }
