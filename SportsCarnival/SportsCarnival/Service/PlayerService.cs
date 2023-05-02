using System;
using MySql.Data.MySqlClient;
using SportsCarnival.Repository;

namespace SportsCarnival
{
	public class PlayerService
	{
        public static List<Player> GetPlayers(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM Player;";
            var reader = MysqlRepo.Get(databaseConnection, query);
            return ParseData(reader);
        }

        public static void SavePlayers(MySql.Data.MySqlClient.MySqlConnection databaseConnection, List<Player> players)
        {
            var obj = new PlayerService();
            for (int i =0; i < players.Count(); i++)
            {
                string query = obj.CreateQuery(players[i]);
                MysqlRepo.Insert(databaseConnection, query);
            }      
        }

        public static void DeleteById(MySql.Data.MySqlClient.MySqlConnection databaseConnection, int id)
        {
            string query = "DELETE FROM Player WHERE playerId="+id.ToString();
            MysqlRepo.DeleteById(databaseConnection, query);
        }

        public static void DeleteAll(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "DELETE FROM Player";
            MysqlRepo.DeleteById(databaseConnection, query);
        }

        private string CreateQuery(Player player)
        {
            string query = "";
            var name = "'"+player.name+"'";
            var id = player.playerId;
            query = "INSERT INTO Player (playerId, playerName) VALUES("+id+", "+name+");";
            return query;
        }

        private static List<Player> ParseData(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            var players = new List<Player>();
            while (reader.Read())
            {
                players.Add(new Player
                {
                    playerId = (int)reader["playerId"],
                    name = (string)reader["playerName"]
                });
            }
            reader.Close();
            return players;
        }
    }
}

