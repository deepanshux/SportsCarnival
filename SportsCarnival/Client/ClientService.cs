using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using CommunicationProtocol;

namespace Client
{
    public class EchoClient
    {
        public static void Main()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8080);
                Console.WriteLine("Connected to server!");

                NetworkStream stream = client.GetStream();
                try
                {
                    SendMessage(stream);
                    ReceiveMessage(stream);
                }
                catch { }
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Server is not running...");
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.Read();
        }

        private static void ReceiveMessage(NetworkStream stream)
        {

            ISCResponse response = new ISCResponse();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            var receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            response = JsonSerializer.Deserialize<ISCResponse>(receivedData);
            Console.WriteLine("Received: {0}", Encoding.ASCII.GetString(response.data, 0, response.data.Length));
        }

        private static void SendMessage(NetworkStream stream)
        {            
            Console.Write("Enter Request: ");
            string inputCommand = Console.ReadLine();

            try
            {
                var request = CreateRequest(inputCommand);
                string serializedRequest = JsonSerializer.Serialize(request);
                byte[] sentBytes = Encoding.ASCII.GetBytes(serializedRequest);
                stream.Write(sentBytes, 0, sentBytes.Length);
                Console.WriteLine("Sent Bytes : {0}", sentBytes.Length);
            }
            catch
            {
                Console.WriteLine("Input command is not valid!");
                throw new Exception();
            }
        }

        private static ISCRequest CreateRequest(string command)
        {
            ISCRequest request = new ISCRequest();
            var trimmedCommand = command.Split().ToList();
            try
            {
                request.METHOD = trimmedCommand[2];
                request.inputPath = trimmedCommand[4];
                request.outputPath = trimmedCommand[6];
            }
            catch
            {
                throw new Exception();
            }
            request.data = SetRequestData(request.inputPath);
            return request;
        }

        private static byte[] SetRequestData(string path)
        {
            string json = File.ReadAllText(@"//" + path);
            return Encoding.ASCII.GetBytes(json);
        }
    }
}