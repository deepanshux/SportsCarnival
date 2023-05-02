using System;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace SportsCarnival.Repository
{
	public class MysqlRepo
	{
        private static MySql.Data.MySqlClient.MySqlConnection databaseConnection = new MySql.Data.MySqlClient.MySqlConnection();
        private static MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

        public static MySql.Data.MySqlClient.MySqlConnection Connect(string user, string password)
		{
            try
            {
                databaseConnection.ConnectionString = "server = localhost; User Id = " + user + "; " +
                "Persist Security Info = True; database = SportsCarnival; password = " + password;
                databaseConnection.Open();
                Console.WriteLine("Succesfully connected to MYSQL !");
            }

            catch (Exception e)
            {
                Console.WriteLine("Not Successful! due to " + e.ToString());
            }

            return databaseConnection;
        }

        public static void Insert(MySql.Data.MySqlClient.MySqlConnection databaseConnection, string query)
        {
            mySqlCommand = new MySqlCommand(query, databaseConnection);
            mySqlCommand.CommandType = System.Data.CommandType.Text;
            try
            {
                int i = mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("Inserted in Table ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not Inserted in table " + ex.Message);
            }

        }

        public static MySql.Data.MySqlClient.MySqlDataReader Get(MySql.Data.MySqlClient.MySqlConnection databaseConnection, string query)
        {
            mySqlCommand = new MySqlCommand(query, databaseConnection);
            MySql.Data.MySqlClient.MySqlDataReader reader = mySqlCommand.ExecuteReader();
            return reader;
        }

        public static void DeleteById(MySql.Data.MySqlClient.MySqlConnection databaseConnection, string query)
        {
            mySqlCommand = new MySqlCommand(query, databaseConnection);
            mySqlCommand.CommandType = System.Data.CommandType.Text;
            try
            {
                int iterator = mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("Data Deleted From table!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot Deleted from table " + exception.Message);
            }
        }

        public static void DeleteAll(MySql.Data.MySqlClient.MySqlConnection databaseConnection, string query)
        {
            mySqlCommand = new MySqlCommand(query, databaseConnection);
            mySqlCommand.CommandType = System.Data.CommandType.Text;
            try
            {
                int iterator = mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("All Records deleted From table !");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cannot Deleted from table " + exception.Message);
            }
        }

        public static void Disconnect()
        {
            databaseConnection.Close();
        }
    }
}
