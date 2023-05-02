using System;
using SportsCarnival.Repository;

namespace SportsCarnival
{
	public class TeamPlayerService
	{
        public static void GetTeamPlayer(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM Team_Player;";
            MysqlRepo.Get(databaseConnection,query);
        }

        public static void SaveTeamPlayer(MySql.Data.MySqlClient.MySqlConnection databaseConnection, List<Team> team)
        {
            for (int i = 0; i < team.Count(); i++)
            {
                InsertData(databaseConnection, team[i].players, team[i].id);
            }
        }

        public static void DeleteById(MySql.Data.MySqlClient.MySqlConnection databaseConnection, int id)
        {
            string query = "DELETE FROM Team_Player WHERE id=" + id.ToString();
            MysqlRepo.DeleteById(databaseConnection, query);
        }

        public static void DeleteAll(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "DELETE FROM Team_Player";
            MysqlRepo.DeleteAll(databaseConnection, query);
        }

        private static void InsertData(MySql.Data.MySqlClient.MySqlConnection databaseConnection, List<Player> players, int teamId)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                string query = CreateQuery(players[i],teamId);
                MysqlRepo.Insert(databaseConnection, query);
            }
        }

        private static string CreateQuery(Player player, int teamId)
        {
            var playerId = player.playerId;
            string query = "INSERT INTO Team_Player (id, playerId, teamId) VALUES(" + 0 + ", " + playerId + ", " + teamId + ");";
            return query;
        }
    }
}

