using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Reflection.PortableExecutable;

namespace CommunicationProtocol
{
    public class Protocol
    {
        public int size;
        public string REQUEST = "request";
        public string RESPONSE = "response";

        public byte[] data { set; get; }
        public string protocolVersion { set; get; } = "";
        public string protocolFormat { set; get; } = "";
        public string protocolType { set; get; } = "";
        public string sourceIp { set; get; } = "";
        public int sourcePort { set; get; } = 0;
        public string destIp { set; get; } = "";
        public int destPort { set; get; } = 0;
        public Hashtable headers { set; get; }
        public string METHOD { set; get; } = "";
        public string inputPath { set; get; } = "";
        public string outputPath { set; get; } = "";

    }

    public class ISCRequest : Protocol
    {
        private Hashtable headerParameter = new Hashtable();

        public ISCRequest()
        {
            this.protocolType = REQUEST;
            this.headers = headerParameter;
        }
    }

    public class ISCResponse : Protocol
    {
        private Hashtable headerParameter = new Hashtable();
        private static string STATUS = "status";
        private static string ERROR_CODE = "error-code";
        private static string ERROR_MESSAGE = "error-message";

        public ISCResponse()
        {
            this.protocolType = RESPONSE;
            headerParameter.Add(STATUS, "");
            headerParameter.Add(ERROR_CODE, "");
            headerParameter.Add(ERROR_MESSAGE, "");
            this.headers = headerParameter;
        }

        public String GetErrorMessage()
        {
            return ERROR_MESSAGE;
        }

        public void SetErrorMessage(string message)
        {
            ERROR_MESSAGE = message;
        }

        public String GetValue(string key)
        {
            if (headers.Contains(key) == true)
            {
                return (string)headers[key];
            }
            return "";
        }

        public void SetValue(string key, string value)
        {
            headerParameter.Add(key, value);
            this.headers = headerParameter;
        }
    }
}