using GameLibraryTracker;

class VideoGameTracker
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Welcome to the Video Game Tracker!");

      // Create a path to the library.
      string path = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/videogametracker/").FullName;
      string libPath;
      if (!File.Exists(path + "data.json"))
      {
        using (var stream = File.Create(path + "data.json"))
        {
          libPath = stream.Name;
        }
      } else
      {
        libPath = path + "data.json";
      }
      
      
      // Load library
      GameLibrary.LoadGames(libPath);
      
      while (true)
      {
        string? command = (Console.ReadLine() ?? string.Empty).ToLower();
        if (command == "exit") break; // allows the program to exit.
        // all other instructions are processed:
        switch (command)
        {
          case "add":
            GameLibrary.AddGame();
            break;
          case "save":
            GameLibrary.WriteOut(libPath);
            break;
          case "load":
            // Loads library from disk
            GameLibrary.LoadGames(libPath);
            foreach (VideoGame game in GameLibrary.Library)
            {
              Console.WriteLine($"Loaded {game.Alias} for {game.Platform}.");
            }
            break;
          case "count":
            Console.WriteLine($"{GameLibrary.Library.Count} games in library");
            break;
          case "help":
            // continue;
          default:
            // exits switch statement if no command is matched.
            Console.WriteLine("Command not found.");
            Console.WriteLine("Command List:");
            Console.WriteLine("help:    Show this help screen.");
            Console.WriteLine("add:     Adds a game to the library. Does not save to disk.");
            Console.WriteLine("load:    Loads library from disk.");
            Console.WriteLine("Save:    Saves library to disk");
            Console.WriteLine("exit:    Exits the program.");
            break;
        }
      }
      
      
    }
  }


  // List<VideoGame> gameLibrary =
      // [
      //   new VideoGame("Persona 5 Royal", "15/01/2019", "Steam"),
      //   new VideoGame("Yakuza Kiwami", "15/01/2019", "Steam", "Yakuza 1"),
      //   new VideoGame("Persona 4 Golden", "15/01/2019", "Steam"),
      //   new VideoGame("Dark Souls: Remastered", "15/01/2018", "Steam", "Dark Souls 1"),
      //   new VideoGame("Civilization 5", "15/01/2020", "Steam"),
      //   new VideoGame("Dragons Dogma", "15/01/2020", "Steam", "Dragons Dogma 1"),
      //   new VideoGame("Dragons Dogma 2", "15/01/2020", "Steam"),
      //   new VideoGame("Final Fantasy 14", "15/01/2020", "Steam"),
      //   new VideoGame("Eiyuden Chronicles", "15/01/2020", "Xbox"),
      //   new VideoGame("Hi-Fi Rush", "15/01/2020", "Xbox"),
      //   new VideoGame("Palworld", "15/01/2020", "Xbox"),
      //   new VideoGame("Dead Space Remake", "15/01/2023", "Xbox"),
      //   new VideoGame("The Legend of Zelda: Breath of the Wild", "15/01/2020", "Nintendo Switch"),
      //   new VideoGame("The Legend of Zelda: Tears of the Kingdom", "15/01/2020", "Nintendo Switch"),
      //   new VideoGame("New Super Mario Bros: Wonder", "15/01/2020", "Nintendo Switch"),
      //   new VideoGame("Mario Kart 8", "15/01/2020", "Nintendo Switch"),  
      // ];