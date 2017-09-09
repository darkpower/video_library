using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace VideoLibrary
{
    class Database
    {
        private static string dbPath = "Data Source = " + Environment.CurrentDirectory + "/library.db";
        private static SQLiteConnection con = new SQLiteConnection(dbPath);
        private static Database database = new Database();

        private Database()
        {
            Database.Init();
        }


        private static void Init()
        {
            if (!tableIsExists("User"))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.CommandText = " CREATE TABLE IF NOT EXISTS User ([Id] integer(4) PRIMARY KEY, [Username] varchar(20), [Password] varchar(20));";
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

            if (tableIsNull("User"))
            {
                SQLiteCommand com = new SQLiteCommand();
                com.CommandText = "INSERT INTO User VALUES (null , 'admin', 'admin');";
                com.Connection = con;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }


        }

        private static Boolean tableIsExists(string tableName)
        {

            SQLiteCommand com = new SQLiteCommand();
            com.CommandText = "SELECT COUNT(*) FROM sqlite_master where type = 'table' and name = '" + tableName + "'";
            com.Connection = con;
            con.Open();
            int count = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Boolean tableIsNull(string tableName)
        {

            SQLiteCommand com = new SQLiteCommand();
            com.CommandText = "SELECT COUNT(*) FROM " + tableName + "";
            com.Connection = con;
            con.Open();
            int count = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Database getInstance()
        {
            return database;

        }

        public Boolean login(string username, string password)
        {

            SQLiteCommand com = new SQLiteCommand();
            com.CommandText = "SELECT COUNT(*) FROM User WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'";
            com.Connection = con;
            con.Open();
            int count = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            if (count == 0)
            {
                return false;
            }
            else if (count == 1)
            {
                return true;

            }
            else
            {
                return false;
            }

        }



    }
}
