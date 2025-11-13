using System.Collections.Generic;

namespace storeList
{
    public static class StoreInfo
    {
        public static List<string> stores = new List<string>();

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

//THE INITIAL LAYOUT OF THE STORELIST, TAKEN DIRECTLY AS IT WAS FROM PROGRAM.CS

//Setting out the list of STORES available across the UK.
// public static List<string> stores = new List<string>();
// stores.Add("London");
// stores.Add("Birmingham");
// stores.Add("Glasgow");
// stores.Add("Liverpool");
// stores.Add("Bristol");
// stores.Add("Manchester");
// stores.Add("Sheffield");
// stores.Add("Leeds");
// stores.Add("Edinburgh");
// stores.Add("Leicester");
// stores.Add("Coventry");
// stores.Add("Bradford");
// stores.Add("Cardiff");