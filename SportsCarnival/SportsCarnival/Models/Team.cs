using System;
namespace SportsCarnival
{
    public class TeamList
    {
        public List<Team> teams = new List<Team>();
        public int total = 0;

        public TeamList(List<Team> teams, int total)
        {
            this.teams = teams;
            this.total = total;
        }
    }

	public class Team
	{
		public int id { set; get; } = 0;
        public string name { set; get; } = "";
        public int gameType { set; get; } = 0;
        public List<Player> players = new List<Player>();

        public Team(int id, string name, int gameType, List<Player> players)
        {
            this.id = id;
            this.name = name;
            this.gameType = gameType;
            this.players = players;
        }
    }

	public class Player
	{
        public int playerId { set; get; } = 0;
        public string name { set; get; } = "";
    }
}

