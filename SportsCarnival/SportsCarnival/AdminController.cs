using System;
namespace SportsCarnival
{
	public class AdminController
	{
		private static List<Team>? teams { set; get; }
        private static MySql.Data.MySqlClient.MySqlConnection databaseConnection = new MySql.Data.MySqlClient.MySqlConnection();

        public AdminController() { }

        public static void CreateTeams(Game game)
		{
			teams = AdminService.CreateTeam(game);

			if(teams.Count != 0)
			{
                CreateJSON();
            }	
		}

        public static void CreateTeamsFromMYSQL()
        {
            databaseConnection = MysqlService.Connect();
            Game game = CreateGame();
			CreateTeams(game);
        }

        public static void SaveTeams()
		{
            databaseConnection = MysqlService.Connect();
			SaveTeamList(databaseConnection);
			MysqlService.Disconnect();
        }

		private static Game GetGameData()
		{
			return JSONService.ReadJSON();
        }

		private static void CreateJSON()
		{
			var teamList = MapTeamList();
			JSONService.WriteJSON(teamList);
		}

		private static TeamList MapTeamList()
		{
			if (teams is not null)
			{
               var teamList = new TeamList(teams, teams.Count);
                return teamList;
            }
			else
			{
				throw new TeamsNotCreatedException();
			}
		}

		private static void SaveTeamList(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
		{
            teams = AdminService.CreateTeam(GetGameData());
			TeamPlayerService.SaveTeamPlayer(databaseConnection, teams);
           
        }

        private static void SavePlayers(MySql.Data.MySqlClient.MySqlConnection databaseConnection)
        {
            for (int i = 0; i < teams.Count(); i++)
            {
                var player = new Player();
                PlayerService.SavePlayers(databaseConnection, teams[i].players);
            }
        }

		private static Game CreateGame()
		{
			var teams = GetTeams();
			var players = GetPlayers();
			return ParseGame(teams,players);
		}

        private static Game ParseGame(List<Team> teams , List<Player> players)
        {
            var game = new Game();
			game.gameType = teams[0].gameType;
			game.players.AddRange(players);
            return game;
        }
		
		private static List<Team> GetTeams()
		{
            var teams = TeamService.GetTeams(databaseConnection);
			return teams;
        }

        private static List<Player> GetPlayers()
        {
            var players = PlayerService.GetPlayers(databaseConnection);
            return players;
        }
    }
}

