using System;
namespace SportsCarnival
{
	public class Global
	{
		private static string ProjectFileDirectory = @"//Users/deepanshujain/Desktop/L&C Project/sportscarnival/SportsCarnival/SportsCarnival/Data/";
        private static string OutputFileDirectory = @"//Users/deepanshujain/Desktop/L&C Project/";
        public static string TeamsInputFile { set; get; } = ProjectFileDirectory + "/TeamsInputJSON.json";
        public static string TeamsOutputFile { set; get; } = ProjectFileDirectory + "/TeamsOutput.json";
        public static string FixtureInputFile = ProjectFileDirectory + "/FixtureInputJSON.json";
        public static string FixtureOutputFile = ProjectFileDirectory + "/FixtureOutputJSON.json";

		public static void SetTeamsOutputFileName(string name)
		{           
			TeamsOutputFile = OutputFileDirectory + name;
		}

        public static void SetTeamsInputPath(string path)
        {
            TeamsInputFile = @"//" + path;
        }

        public static void SetTeamsOutputPath(string path)
        {
            TeamsOutputFile = @"//" + path;
        }
    }
	
}

