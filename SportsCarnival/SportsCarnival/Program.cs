// See https://aka.ms/new-console-template for more information
using System.Text;
using SportsCarnival;

//MultiThreadedEchoServer.Main();
var game = JSONService.ReadJSON();
AdminController.CreateTeams(game);




