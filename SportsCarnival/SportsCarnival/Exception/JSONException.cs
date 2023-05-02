using System;
namespace SportsCarnival
{
	public class JSONException : Exception
	{
		public JSONException() { }

        public JSONException (string IncorrectFormat) : base(String.Format("JSON Format is Incorrect",IncorrectFormat))
        {
            
        }

    }
}

