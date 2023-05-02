using System;
namespace SportsCarnival
{
	public class CommunicationException : Exception
	{
		public CommunicationException() { }

        public CommunicationException(string method) : base(String.Format("Input Method not Found - " + method))
        {

        }
    }
}

