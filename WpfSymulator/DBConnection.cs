using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSymulator
{
    /// <summary>
    /// Class used to establish a connection with an SQLite database
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// Method creating a table of player names in a database
        /// </summary>
        public static void CreateTable() 
        {
            string dbFile = "URI=file:SQLiteDB.db";
            SQLiteConnection dbConnection = new SQLiteConnection(dbFile);
            dbConnection.Open();
            string table = "create table DBPlayer (ID integer primary key, NAME text);";
            SQLiteCommand dbCommand = new SQLiteCommand(table, dbConnection);
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
        /// <summary>
        /// Method adding a player to a database
        /// </summary>
        /// <param name="name">Name of the player being added</param>
        /// <exception cref="Exception">Exception thrown when a name already exists in a database</exception>
        public static void AddPlayer(string name) 
        {
            string dbFile = "URI=file:SQLiteDB.db";
            SQLiteConnection dbConnection = new SQLiteConnection(dbFile);
            dbConnection.Open();
            string searchForDuplicates = $"select * from DBPlayer where name = '{name}';";
            SQLiteCommand searchCommand = new SQLiteCommand(searchForDuplicates, dbConnection);
            SQLiteDataReader reader = searchCommand.ExecuteReader();
            if (reader.HasRows)
            {
                throw new Exception("Name already taken!");
            }
            else
            {
                string insertPlayer = $"insert into DBPlayer (NAME) values ('{name}');";
                SQLiteCommand insertCommand = new SQLiteCommand(insertPlayer, dbConnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Player '{name}' added to the database.");
            }
            reader.Close();
            dbConnection.Close();
        }
        /// <summary>
        /// Method retrieving player names from a database
        /// </summary>
        /// <returns>A list of strings containing player names</returns>
        public static List<string> GetPlayerList() 
        {
            List<string> playerNames = new List<string>();
            string dbFile = "URI=file:SQLiteDB.db";
            SQLiteConnection dbConnection = new SQLiteConnection(dbFile);
            dbConnection.Open();
            string getPlayers = "select NAME from DBPlayer;";
            SQLiteCommand getCommand = new SQLiteCommand(getPlayers, dbConnection);
            SQLiteDataReader reader = getCommand.ExecuteReader();

            while (reader.Read())
            {
                string playerName = reader["NAME"].ToString();
                playerNames.Add(playerName);
            }

            reader.Close();
            dbConnection.Close();
            return playerNames;
        }
        /// <summary>
        /// Method clearing the table of player names from a database
        /// </summary>
        public static void DeleteAllPlayers()
        {
            string dbFile = "URI=file:SQLiteDB.db";
            using (SQLiteConnection dbConnection = new SQLiteConnection(dbFile))
            {
                dbConnection.Open();

                string deleteRows = "DELETE FROM DBPlayer;";
                using (SQLiteCommand dbCommand = new SQLiteCommand(deleteRows, dbConnection))
                {
                    dbCommand.ExecuteNonQuery();
                }

                dbConnection.Close();
            }
        }

    }
}
