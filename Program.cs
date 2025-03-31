using GameLibraryTracker;

class VideoGameTracker
{
	static void Main(string[] args)
	{

		Console.WriteLine("Welcome to the Video Game Tracker!");
		string path = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/videogametracker/").FullName;

		while (true)
		{
			Console.Write(">> ");
			string command = (Console.ReadLine() ?? string.Empty).ToLower();
			if (command == "exit") break; // allows the program to exit.
			string? filter;

			// all other instructions are processed:
			switch (command.Split(" ")[0])
			{
				case "add": // Adds a game to the library.
					GameLibrary.AddGame();
					break;
					
				case "save": // Saves game library to list.
					GameLibrary.Save(path);
		  			break;
					
				case "load": // Loads library from disk
					GameLibrary.Load(path);
					break;
					
				case "list": // Lists all games in library.
					foreach (VideoGame game in GameLibrary.Library)
					{
						Console.WriteLine(game.Alias);
					}
					break;
					
				case "filter":
					try
					{
						filter = command.Split(" ")[1];
					}
					catch (IndexOutOfRangeException)
					{
						Console.WriteLine("Error: Unable to parse command.");
						Console.WriteLine("Usage: 'filter {platform}'");
						break;
					}
					GameLibrary.ListGames(filter);
					break;
					
				case "remove":
					try
					{
						filter = command.Split(" ")[1];
					}
					catch (IndexOutOfRangeException)
					{
						Console.WriteLine("Error: Unable to parse command.");
						Console.WriteLine("Usage: 'remove {game}'");
						break;
					}
					GameLibrary.RemoveGame(filter);
					break;

				case "count": // Outputs the number of games in the library.
					Console.WriteLine($"{GameLibrary.Library.Count} games in library");
					break;
					
				case "help":
				// continue to default
				default:
					// exits switch statement if no command is matched.
					Console.WriteLine("Command List:");
					Console.WriteLine("help:    Show this help screen.");
					Console.WriteLine("add:     Adds a game to the library. Does not save to disk.");
					Console.WriteLine("filter:  Filters the library for a given platform.");
					Console.WriteLine("load:    Loads library from disk.");
					Console.WriteLine("save:    Saves library to disk");
					Console.WriteLine("exit:    Exits the program.");
					break;
			}
		}


	}
}