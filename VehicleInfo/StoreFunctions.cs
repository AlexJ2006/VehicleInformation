using storeList;

namespace VehicleInfo
{
    public static class StoreFunctions
    {
        public static void storeAdd()
        {

            var stores = StoreInfo.stores;
            
            Console.Write("Please enter the name of the store you wish to add: ");
            string addStoreName = Console.ReadLine()!;
            stores.Add(addStoreName);
        }
        public static void storeListDisplay()
        {
            var stores = StoreInfo.stores;

            foreach (string store in stores)
            {
                Console.WriteLine(store);
            }
        }
    }
}
