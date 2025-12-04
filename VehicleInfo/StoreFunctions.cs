
using StoreList;

namespace VehicleInfo
{
    //Setting out the various store functions (allowing the staff users to manipulate the store list in various ways)
    public static class StoreFunctions
    {
        //Allowing them to add stores
        public static void storeAdd()
        {

            var stores = StoreInfo.Stores; //Setting the variable as the storelist

            Console.Write("Please enter the name of the store you wish to ADD: "); //Asking them to enter the name of the store they wish to add
            string addStoreName = Console.ReadLine()!;

            if (!stores.Contains(addStoreName)) //If the store list doesn't contain the name that they have provided
            {
                stores.Add(addStoreName); //The store is added to the list
                Console.ForegroundColor = ConsoleColor.Green; //Manually changing the colour to green
                Console.WriteLine("STORE ADDED, thank you."); //Letting the user know that the store has been added
                Console.ResetColor();
                
                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?");
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If they have selected yes
                {
                    storeListDisplay(); //Displaying the store list
                }
                else //If not...
                {
                    Console.WriteLine("Process complete. Thank you.");//Letting them know that the process is complete

                }
            }
            else //If the store already exists within the list...
            {
                Utilities.errorRedWarning(); //Displays WARNING: in red
                Console.WriteLine("This Store Already exists within the list"); //Giving the user a warning that the store already exists 

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?"); //Asking the user if they wish to view the list
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;
 
                if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If yes...
                {
                    storeListDisplay(); //Displaying the list
                }
                else //If anything else
                {
                    Console.ForegroundColor = ConsoleColor.Red; //Changing the colour to red
                    Console.WriteLine("Please RETRY.");
                    Console.ResetColor();
                }
            }
        }
        //Function for the removal of stores
        public static void storeRemove()
        {
            var stores = StoreInfo.Stores; //Again, setting the variable as the store list

            Console.WriteLine("Please enter the name of the store you wish to remove from the list"); //Asking the user for the input of which store they wish to remove
            string removeStoreName = Console.ReadLine()!;

            if (stores.Contains(removeStoreName)) //If the store they have entered is present within the list
            {
                stores.Remove(removeStoreName); //The store is removed from the list

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?"); //Asking the user if they would like to view the list
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    storeListDisplay(); //Displaying the list
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; //Changing the colour to green, manually again.
                    Console.WriteLine("Process complete. Thank you."); //Letting them know that the process is complete
                    Console.ResetColor();
                    
                }
            }
            //If the store that they have requested to remove cannot be found within the list
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("This Store DOES NOT EXIST within the list"); //The user is warned that the store does not exist within the list

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?"); //They are asked if they would like to view the list
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList.Equals("Y", StringComparison.OrdinalIgnoreCase)) //If yes...
                {
                    storeListDisplay(); //The store list is displayed
                }
                else //Else
                {
                    Console.ForegroundColor = ConsoleColor.Red; //Changing the colour to red
                    Console.WriteLine("Please RETRY.");
                    Console.ResetColor();
                }
            }
        }
        //The function that displays the storelist (called multiple times within this file)
        public static void storeListDisplay()
        {
            var stores = StoreInfo.Stores; //Setting the variable as the storelist

            foreach (string store in stores) //Foreach one of the stores within the storelist
            {
                Console.WriteLine(store); //Print the store name
            }
        }
        //The function that clears the storelist
        public static void storeListClear()
        {
            var stores = StoreInfo.Stores;

            stores.Clear();
        }
        //The function that sorts the storelist (alphabetically)
        public static void storeListSort()
        {
            var stores = StoreInfo.Stores;
            stores.Sort();
        }
        
    }
}
