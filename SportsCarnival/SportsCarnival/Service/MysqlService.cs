using System;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SportsCarnival.Repository;

namespace SportsCarnival
{
	public class MysqlService
	{
        private static MySql.Data.MySqlClient.MySqlConnection databaseConnection = new MySql.Data.MySqlClient.MySqlConnection();

        public static MySql.Data.MySqlClient.MySqlConnection Connect()
        {
            databaseConnection = MysqlRepo.Connect("root", "abcd1234");
            return databaseConnection;
        }

        public static void Disconnect()
        {
            MysqlRepo.Disconnect();
        }
    }
}

