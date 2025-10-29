using System;
using System.Data.SQLite;
using System.Security.Permissions;

namespace UserRentalData
{
    public static class UserDatabaseManager
    {
        private static string databaseFile = "userInfo.db";
        private static string dbConnection = $"Data Source={databaseFile};Version=3;";

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(dbConnection))
            {
                connection.Open();

                string createUserInfoTable = @"
                CREATE TABLE IF NOT EXISTS UserInfo (
                User_ID INTEGER PRIMARY KEY NOT NULL,
                User_Password TEXT NOT NULL,
                First_Name TEXT NOT NULL,
                Last_Name TEXT NOT NULL, 
                DoB INTEGER NOT NULL,
                Contact_Number INTEGER NOT NULL);";

                using (var cmd = new SQLiteCommand(createUserInfoTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(dbConnection);
        }

        public static bool RegisteredUser(string User_ID, string User_Password, string First_Name, string Last_Name, string DoB, string Contact_Number)
        {
            using (var connection = UserDatabaseManager.GetConnection())
            {
                connection.Open();

                string insertQuery = @"
                INSERT INTO UserInfo (User_ID, User_Password, First_Name, Last_Name, DoB, Contact_Number)
                VALUES (@User_ID, @User_Password, @First_Name, @Last_Name, @DoB, @Contact_Number);";

                using (var cmd = new SQLiteCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@User_ID", User_ID);
                    cmd.Parameters.AddWithValue("@User_Password", User_Password);
                    cmd.Parameters.AddWithValue("@First_Name", First_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", Last_Name);
                    cmd.Parameters.AddWithValue("@DoB", DoB);
                    cmd.Parameters.AddWithValue("@Contact_Number", Contact_Number);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Your account has been registered. THANK YOU.");
                        return true;
                    }
                    catch (SQLiteException ex)
                    {
                        Console.WriteLine($"Your account could not be registered. PLEASE RETRY.");
                        return false;
                    }
                }
            }
        }

        public static bool ValidateUserLogIn(string User_ID, string User_Password)
        {
            using (var connection = UserDatabaseManager.GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM UserInfo WHERE User_ID = @User_ID AND User_Password = @User_Password;";

                using (var cmd = new SQLiteCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@User_ID", User_ID);
                    cmd.Parameters.AddWithValue("@User_Password", User_Password);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
