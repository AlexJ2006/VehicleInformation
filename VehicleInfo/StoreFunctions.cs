using storeList;

namespace VehicleInfo
{
    public static class StoreFunctions
    {
        public static void storeAdd()
        {
            var stores = StoreInfo.stores;

            Console.Write("Please enter the name of the store you wish to ADD: ");
            string addStoreName = Console.ReadLine()!;

            if (!stores.Contains(addStoreName))
            {
                stores.Add(addStoreName);
                Console.WriteLine("STORE ADDED, thank you.");
                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?");
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList == "Y" || viewList == "y")
                {
                    storeListDisplay();
                }
                else
                {
                    Console.WriteLine("Process complete. Thank you.");
                }
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("This Store Already exists within the list");

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?");
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList == "Y" || viewList == "y")
                {
                    storeListDisplay();
                }
                else
                {
                    Console.WriteLine("Please RETRY.");
                }
            }
        }
        public static void storeRemove()
        {

            var stores = StoreInfo.stores;

            Console.WriteLine("Please enter the name of the store you wish to remove from the list");
            string removeStoreName = Console.ReadLine()!;

            if (stores.Contains(removeStoreName))
            {
                stores.Remove(removeStoreName);

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?");
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList == "Y" || viewList == "y")
                {
                    storeListDisplay();
                }
                else
                {
                    Console.WriteLine("Process complete. Thank you.");
                }
            }
            else
            {
                Utilities.errorRedWarning();
                Console.WriteLine("This Store DOES NOT EXIST within the list");

                Utilities.insertBreak();
                Console.WriteLine("Would you like to view the list?");
                Console.Write("Y OR N: ");
                string viewList = Console.ReadLine()!;

                if (viewList == "Y" || viewList == "y")
                {
                    storeListDisplay();
                }
                else
                {
                    Console.WriteLine("Please RETRY.");
                }
            }
        }
        public static void storeListDisplay()
        {
            var stores = StoreInfo.stores;

            foreach (string store in stores)
            {
                Console.WriteLine(store);
            }
        }
        public static void storeListClear()
        {
            var stores = StoreInfo.stores;

            stores.Clear();
        }
        public static void storeListSort()
        {
            var stores = StoreInfo.stores;
            stores.Sort();
        }
        
    }
}
