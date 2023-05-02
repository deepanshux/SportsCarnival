using System;
namespace SportsCarnival
{
	public class Constants
	{
		public static Dictionary<int, int> requiredPlayers = new Dictionary<int, int>()
		{
			{1, (int)GameTypeEnum.Cricket},
            {2, (int)GameTypeEnum.Badminton},
            {3, (int)GameTypeEnum.Chess}
        };
	}
}

