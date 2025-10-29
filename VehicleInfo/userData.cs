using System;
using System.Data.SQLite;

namespace UserRentalData
{
    public static class UserDatabaseManager
    {
        private static string databaseFile = "userInfo.db";
        private static string dbConnection = ($"Data Source = {databaseFile}");
        

        public static void IniializeDatabase()
        {
            using (var connection = new SQLiteConnection())
            {
                connection.Open();

                string createUserInfoTable = @"
                CREATE TABLE IF NOT EXISTS UserInfo (
                User_ID INTEGER PRIMARY KEY NOT NULL,
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
    }
}
