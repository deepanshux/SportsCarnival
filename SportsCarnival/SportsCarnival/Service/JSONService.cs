using System;
using SportsCarnival.Repository;
using System.Text.Json;

namespace SportsCarnival
{
	public class JSONService
	{
		public static Game ReadJSON()
		{
			var game = new Game();
            using (StreamReader reader = new StreamReader(Global.TeamsInputFile))
            {
                try
                {
                    game = (Game)JSONSerializer.Deserialize(reader, typeof(Game));
                }
                catch(JSONException ex)
                {
                    WriteErrorJSON(ex.Message);
                }
            }
            return game;
		}

		public static void WriteJSON(TeamList teams) 
		{
            var json = JSONConvert.SerializeObject(teams);
            File.WriteAllText(Global.TeamsOutputFile, json);
            Console.WriteLine("JSON file has been created successfully.");
		}

        public static void WriteErrorJSON(string description)
        {
            var json = CreateErrorJSON(description);
            File.WriteAllText(Global.TeamsOutputFile, json);
        }

        private static string CreateErrorJSON(string description)
        {
            var jsonModel = new JSONError(descriptionMessage : description);
            return JSONConvert.SerializeObject(jsonModel);
        }
    }
}

