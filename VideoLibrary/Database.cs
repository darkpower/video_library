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
        private static string dbPath = "Data Source = " + Environment.CurrentDirectory + "\\Data\\data.db";
        private static SQLiteConnection con = new SQLiteConnection(dbPath);
        private static Database database = new Database();

        private Database()
        {

        }

        public static Database getInstance() {
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
