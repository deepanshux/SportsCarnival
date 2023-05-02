using System;
namespace SportsCarnival
{
    [Serializable]
    public class TeamsNotCreatedException :  Exception
	{
		public TeamsNotCreatedException() { }

        public TeamsNotCreatedException(int count) : base (String.Format("Total number of players are less for team creation", count))
        {

        }

        public TeamsNotCreatedException(string id) : base(String.Format("Player id can not be in string", id))
        {

        }

        public TeamsNotCreatedException(bool check) : base(String.Format("Player name can not null", check))
        {

        }

    }
}

