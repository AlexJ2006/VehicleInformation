using System.Diagnostics;

namespace VehicleInfo
{
    public static class AdminFunctions
    {
        public static void RemoveStaff(int staffID, string firstName, string lastName)
        {
            StaffData.LoadFromBinary();

            var staff = StaffData.staffDict.FirstOrDefault(s =>
                s.Value.GetUserID() == staffID &&
                s.Value.GetFirstName().Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                s.Value.GetLastName().Equals(lastName, StringComparison.OrdinalIgnoreCase)
            );

            if (staff.Equals(default(KeyValuePair<int, Staff>)))
            {
                Utilities.errorRedWarning();
                Console.WriteLine("Could not find the staff member within the list");
                return;
            }

            StaffData.staffDict.Remove(staff.Key);
            StaffData.SaveToBinary();

            Console.WriteLine($"Staff member {firstName} {lastName} (ID: {staffID}) removed successfully.");
        }
        public static void GenerateStaffReport()
        {
            StaffData.LoadFromBinary();
            var staffList = StaffData.staffDict.Values.ToList();

            Console.WriteLine("Running simple parallel demo...");

            //Using single-core processing
            var sw1 = Stopwatch.StartNew();
            foreach (var s in staffList)
            {
                DummyCalculation();
            }
            sw1.Stop();

            //Using parallel processing
            var sw2 = Stopwatch.StartNew();
            Parallel.ForEach(staffList, staff =>
            {
                DummyCalculation();
            });
            sw2.Stop();

            //Displaying the times to the user
            Console.WriteLine($"Single-Core time: {sw1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Parallel Processing time:        {sw2.ElapsedMilliseconds} ms");
        }

        private static void DummyCalculation()
        {
            //Creating a CPU intensive calculation
            for (int i = 0; i < 4000; i++) { }
        }
        
        public static void ViewAllStaff()
        {
            //Loading the data from the binary file
            StaffData.LoadFromBinary();

            //Ensuring that the dictionary isn't empty and the process can continue 
            if (StaffData.staffDict.Count == 0)
            {
                Console.WriteLine("No staff members found in the system.");
                return;
            }

            //Creating a nice display to enhance the UX
            Console.WriteLine("================ STAFF MEMBERS ================");

            //Looping over each of the staff
            foreach (var pair in StaffData.staffDict)
            {
                int id = pair.Value.GetUserID();
                string first = pair.Value.GetFirstName();
                string last = pair.Value.GetLastName();

                //Displaying each of them
                Console.WriteLine($"ID: {id}   |   Name: {first} {last}");
            }

            //The end of the display
            Console.WriteLine("================================================");
        }

    }
}
