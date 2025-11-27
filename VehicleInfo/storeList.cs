using System.Collections.Generic;

namespace storeList
{
    //Setting out the storelist
    public static class StoreInfo
    {
        public static List<string> stores = new List<string>(); //Creating a list of strings for the stores

        //Adding all of the stores to the list
        static StoreInfo()
        {
            stores.Add("London");
            stores.Add("Birmingham");
            stores.Add("Glasgow");
            stores.Add("Liverpool");
            stores.Add("Bristol");
            stores.Add("Manchester");
            stores.Add("Sheffield");
            stores.Add("Leeds");
            stores.Add("Edinburgh");
            stores.Add("Leicester");
            stores.Add("Coventry");
            stores.Add("Bradford");
            stores.Add("Cardiff");
        }
    }
}