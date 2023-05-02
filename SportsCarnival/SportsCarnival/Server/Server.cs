using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.Json;
using SportsCarnival;
using System.Linq;
using System.Text.Encodings.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CommunicationProtocol;
using Org.BouncyCastle.Asn1.Ocsp;

public class MultiThreadedEchoServer
{
    static List<TcpClient> clients = new List<TcpClient>();

    public static void Main()
    {
        TcpListener? listener = null;
        try
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            listener.Start();
            Console.WriteLine("Server started...");
            while (true)
            {
                Console.WriteLine("Waiting for incoming client connections...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Accepting new client connection...");
                Console.WriteLine("Client connected: {0}", client.Client.RemoteEndPoint);
                clients.Add(client);
                Console.WriteLine("Active Clients: {0}", clients.Count);
                Thread thread = new Thread(ProcessClientRequests);
                thread.Start(client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }

    private static void ProcessClientRequests(object argument)
    {
        TcpClient client = (TcpClient)argument;
        try
        {
            StreamReader reader = new StreamReader(client.GetStream());
            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream, client);
            SendResponse(stream);
            Console.WriteLine("Closing client connection : {0}", client.Client.RemoteEndPoint);
            client.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Problem with client communication. Exiting thread.", e);
        } 
        finally
        {
            if (client != null)
            {   
                clients.Remove(client);
                Console.WriteLine("Client disconnected !");
                client.Close();
            }
        }
    }

    private static void ReceiveMessage(NetworkStream stream, TcpClient client)
    {
        ISCRequest request = new ISCRequest();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine("Received From: {0} : {1}", client.Client.RemoteEndPoint, Encoding.ASCII.GetString(buffer, 0, bytesRead));

        var receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        try
        {
            request = JsonSerializer.Deserialize<ISCRequest>(receivedData);
            SetOutputPath(request);
            CheckMethod(request);
            CreateTeams(request);
        }
        catch(CommunicationException ex)
        {
            SendException(ex.Message, stream);
        }
    }

    private static void SendResponse(NetworkStream stream)
    {
        var response = SetResponse();
        string serializedResponse = JsonSerializer.Serialize(response);
        byte[] bytes = Encoding.ASCII.GetBytes(serializedResponse);
        stream.Write(bytes, 0, bytes.Length);
    }

    private static void CreateTeams(ISCRequest request)
    {
        var gameString = Encoding.ASCII.GetString(request.data, 0, request.data.Length);
        using (TextReader reader = new StringReader(gameString))
        {
            try
            {
                StartCreating(reader);
            }
            catch(JsonException ex)
            {
                JSONService.WriteErrorJSON(ex.Message);
            }
        }            
    }

    private static void StartCreating(TextReader reader)
    {
        var game = ParseGame(reader);

        if(IsPlayerCountValid(game))
        {          
            AdminController.CreateTeams(game);
        }
        else
        {
            throw new JsonException("Inccorect Data Format");
        }
    }

    private static void CheckMethod(ISCRequest request)
    {
        if (request.METHOD != "create_team")
        {
            throw new CommunicationException(request.METHOD);
        }
    }

    private static void SendException(string message,NetworkStream stream)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(message);
        stream.Write(bytes, 0, bytes.Length);
    }

    private static Game ParseGame(TextReader reader)
    {
        var game = new Game();
        try
        {
            game = (Game)JSONSerializer.Deserialize(reader, typeof(Game));
        }
        catch { }
        return game;
    }

    private static bool IsPlayerCountValid(Game game)
    {
        return game.players.Count != 0 ? true : false;
    }

    private static byte[] SetResponseData()
    {
        string responseData = "JSON has been created Successfully!";
        return Encoding.ASCII.GetBytes(responseData);
    }

    private static ISCResponse SetResponse()
    {
        ISCResponse response = new ISCResponse();
        response.data = SetResponseData();
        response.RESPONSE = "";
        return response;
    }

    private static void SetOutputPath(ISCRequest request)
    {
        Global.TeamsOutputFile = @"//"+request.outputPath;
    }
}