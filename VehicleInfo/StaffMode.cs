using System;
using VehicleInfo;

namespace VehicleInfo.Services
{
    public class StaffService
    {
        public void StartStaffMode(Staff staff)
        {
            while (true)
            {
                Utilities.Utilities.insertBreak();
                Console.WriteLine("WELCOME STAFF");
                Utilities.Utilities.insertBreak();
                Console.WriteLine("Which of the following functions would you like to perform?");
                Utilities.Utilities.insertBreak();
                Console.WriteLine("A) ADD VEHICLES");
                Utilities.Utilities.insertBreak();
                Console.WriteLine("R) REMOVE VEHICLES");
                Utilities.Utilities.insertBreak();
                Console.WriteLine("E) EDIT STORE LIST");
                Utilities.Utilities.insertBreak();
                Console.Write("Please Enter Your Choice: ");
                string? staffMenuChoice = Console.ReadLine();
                Utilities.Utilities.insertBreak();

                string selection = Console.ReadLine()!.Trim();

                switch (selection)
                {
                    case "A":
                        AddVehicle();
                        break;

                    case "R":
                        RemoveVehicle();
                        break;

                    case "E":
                        EditStoreList();
                        break;

                    case "4":
                        Console.WriteLine("Logging out...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void AddVehicle()
        {
            Console.WriteLine("Add vehicle function goes here.");
        }

        private void RemoveVehicle()
        {
            Console.WriteLine("Remove vehicle function goes here.");
        }

        private void ListVehicles()
        {
            Console.WriteLine("List vehicles function goes here.");
        }
    }
}
