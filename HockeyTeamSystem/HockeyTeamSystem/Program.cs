// See https://aka.ms/new-console-template for more information
using HockeyTeamSystem;

// Test with valid full name, primary number
HockeyPlayer player1 = new("    Connor McDavid      ", 97, PlayerPosition.Center);
Console.WriteLine(player1); // The HockeyPlayer.ToString() will be invoked indirectly

// Test with null for FullName
try
{
    HockeyPlayer player2 = new(null, 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}

// Test with empty string for FullName
try
{
    HockeyPlayer player3 = new("", 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Test with whitespace for FullName
try
{
    HockeyPlayer player4 = new("    ", 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Test with less than 3 characters for FullName
try
{
    HockeyPlayer player5 = new("Hi", 97, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Test with invalid PrimaryNumber - outside of minimum range
try
{
    HockeyPlayer player6 = new("Connor McDavid", 0, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Test with invalid PrimaryNumber - outside of maximum range
try
{
    HockeyPlayer player7 = new("Connor McDavid", 100, PlayerPosition.Center);
    Console.WriteLine("Test case has failed.");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}