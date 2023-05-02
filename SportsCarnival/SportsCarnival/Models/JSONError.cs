using System;
namespace SportsCarnival
{
	public class JSONError
	{
		public string type = "Error";
        public string message = "Incorrect Data Format";
        public string description { set; get; } = "Players not enough";

        public JSONError(string descriptionMessage)
        {
            type = "Error";
            message = "Incorrect Data Format";
            description = descriptionMessage;
        }
    }
}

