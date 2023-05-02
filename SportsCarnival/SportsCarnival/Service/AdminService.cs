using System;
using System.Linq;
using System.Runtime.InteropServices;
using SportsCarnival.Repository;
using SportsCarnival.Service;

namespace SportsCarnival
{
	public class AdminService
	{
        private static int requiredPlayersCount = 0;
		public AdminService()
		{
		}
        public static List<Team> CreateTeam(Game game)
		{
			var teams = new List<Team>();
            try
            {
                CheckValidJSON(game);
                teams = StartCreatingTeam(game);
                Console.WriteLine("Team List has been Created Successfully.");
            }
            catch(TeamsNotCreatedException ex)
            {
                Console.WriteLine(ex.Message);
                JSONService.WriteErrorJSON(ex.Message);
            }
            return teams;
		}

        public List<Fixture> Createfixtures(TeamList teamList, List<Occasion> holidayList, Events events)
        {
            var fixtureList = new List<Fixture>();
            
            fixtureList.Add(new Fixture()
            {
                gameId = 1,

            });

            return fixtureList;
        }

        private static void CheckValidJSON(Game game)
        {
            if (PlayersNotEnough(game))
            {
                throw new TeamsNotCreatedException(requiredPlayersCount);
            }
            else if (IsPlayerIDString(game))
            {
                throw new TeamsNotCreatedException("");
            }
            else if (IsPlayerNameNull(game))
            {
                throw new TeamsNotCreatedException(true);
            }
        }

        public static int GetNumberOfPlayers(int gameType)
		{
            return Constants.requiredPlayers.ContainsKey(gameType) ? Constants.requiredPlayers[gameType] : 0;
        }

        private static List<Team> StartCreatingTeam(Game game)
		{
            var teams = new List<Team>();
            int count = 1;
			int teamsCount = GetNumberOfTeams(game);

            while (teamsCount != 0)
			{
                var player = new List<Player>();
                player.AddRange(game.players.Take(requiredPlayersCount));
                game.players.RemoveRange(0, requiredPlayersCount);

                var name = "Team - " + count;
                teams.Add(new Team(count, name, game.gameType, player.ToList()));

                count++;
                teamsCount--;
			}
            return teams;
        }

        public static bool PlayersNotEnough(Game game)
        {
            bool check = false;
            requiredPlayersCount = GetNumberOfPlayers(game.gameType);

            if (game.players.Count < 2 * (requiredPlayersCount))
            {
                check = true;
            }
            return check;
        }

        public static int GetNumberOfTeams(Game game)
		{
            int count = 0;
            try
            {
               count = game.players.Count / requiredPlayersCount;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception while getting number of teams" + ex.Message);
            }
            
            return count;
		}

        public static bool IsPlayerIDString(Game game)
        {
            bool check = false;
            foreach (var player in GetPlayersList(game))
            {
                if (player.playerId == 0)
                {
                    check = true;
                }
            }
            return check;
        }

        public static bool IsPlayerNameNull(Game game)
        {
            bool check = false;
            foreach(var player in GetPlayersList(game))
            {
                if(player.name == "")
                {
                    check = true;
                }
            }
            return check;
        }

        private static List<Player> GetPlayersList(Game game)
        {
            var playerList = new List<Player>();
            playerList.AddRange(game.players);
            return playerList;
        }
	}
}

