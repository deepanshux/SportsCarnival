using System;
using SportsCarnival.Repository;

namespace SportsCarnival
{
	public class TeamService
	{
        public static List<Team> GetTeams(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "SELECT * FROM Team;";
            var reader = MysqlRepo.Get(databaseConnection, query);
            return ParseTeam(reader);
        }

        public static void SaveTeams(MySql.Data.MySqlClient.MySqlConnection databaseConnection, List<Team> team)
        {
            var obj = new TeamService();
            for (int i = 0; i < team.Count(); i++)
            {
                string query = obj.CreateQuery(team[i], i);
                MysqlRepo.Insert(databaseConnection, query);
            }
        }

        public static void DeleteById(MySql.Data.MySqlClient.MySqlConnection databaseConnection, int id)
        {
            string query = "DELETE FROM Team WHERE teamId=" + id.ToString();
            MysqlRepo.DeleteById(databaseConnection, query);
        }

        public static void DeleteAll(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            string query = "DELETE FROM Team";
            MysqlRepo.DeleteById(databaseConnection, query);
        }

        private string CreateQuery(Team team, int eventID)
        {
            string query = "";
            var name = "'" + team.name + "'";
            var id = team.id;
            var gameType = team.gameType;
            query = "INSERT INTO Team (teamId, name, eventId, gameId) VALUES(" + id + ", " + name + ", " + eventID + ", " + gameType + ");";
            return query;
        }

        private static List<Team> ParseTeam(MySql.Data.MySqlClient.MySqlDataReader reader)
        {
            var teams = new List<Team>();
            var playerList = new List<Player>();
            while (reader.Read())
            {
                teams.Add(new Team((int)reader["teamId"], (string)reader["name"], (int)reader["gameId"],playerList));
            }
            reader.Close();
            return teams;
        }
    }
}

