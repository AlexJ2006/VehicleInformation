using VehicleInfo;

namespace VehicleManagement
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
    }
}
