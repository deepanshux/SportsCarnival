using System;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using SportsCarnival.Repository;

namespace SportsCarnival
{
	public class GameService
	{
        public static void GetGameType(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM GameType;";
            MysqlRepo.Get(databaseConnection,query);
        }
    }
}

