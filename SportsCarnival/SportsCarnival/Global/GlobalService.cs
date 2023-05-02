using System;
using System.Text.RegularExpressions;
namespace SportsCarnival
{
	public class GlobalService
	{
		private static string expression = @"\A(^isc -a$)";

		public static bool isValidCommand(string command)
		{
			Regex regex = new Regex(expression);

			if (regex.IsMatch(command))
				return true;
			else
				return false;
		}
	}
}

