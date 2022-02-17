// See https://aka.ms/new-console-template for more information
using ListManipulationDemo;
using System.Text.Json;

HockeyTeam edmontonOilers = new HockeyTeam("Edmonton Oilers");

foreach(var player in edmontonOilers.Players)
{
    Console.WriteLine(player);
}

Console.WriteLine();
Console.WriteLine("------------");
Console.WriteLine();

var splitTeam = edmontonOilers.Split(5);

foreach (var player in edmontonOilers.Players)
{
    Console.WriteLine(player);
}

Console.WriteLine();
Console.WriteLine("------------");
Console.WriteLine();

foreach (var player in splitTeam)
{
    Console.WriteLine(player);
}


Console.WriteLine();
Console.WriteLine("Nait tests");
Console.WriteLine("------------");
Console.WriteLine();

HockeyTeam naitOoks = new HockeyTeam("Nait Ooks");
var demotedPlayers = naitOoks.Split("Zach Hyman");

Console.WriteLine("Players left in the team after Zach Hyman");
foreach(var player in naitOoks.Players)
{
    Console.WriteLine(player);
}

Console.WriteLine();
Console.WriteLine("------------");
Console.WriteLine();

Console.WriteLine("Players demoted to Nait Ooks after Zach Hyman");
foreach (var player in demotedPlayers)
{
    Console.WriteLine(player);
}


const string HockeyPlayerCSVFile = "../../../HockeyPlayers.csv";
const string HockeyTeamJsonFile = "../../../HockeyPlayers.json";

try
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    string jsonString = JsonSerializer.Serialize<HockeyTeam>(edmontonOilers, options);
    File.WriteAllText(HockeyTeamJsonFile, jsonString);
}

catch (Exception ex)
{
    Console.WriteLine("Haseeb is incorrect");
}

