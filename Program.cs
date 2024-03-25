﻿using GameLibraryTracker;

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
        Console.Write(">> ");
        string command = (Console.ReadLine() ?? string.Empty).ToLower();
        if (command == "exit") break; // allows the program to exit.
        // all other instructions are processed:
        switch (command)
        {
          case "add": // Adds a game to the library.
            GameLibrary.AddGame();
            break;
          case "save": // Saves game library to list.
            GameLibrary.WriteOut(libPath);
            Console.WriteLine("Save complete!");
            break;
          case "load": // Loads library from disk
            GameLibrary.LoadGames(libPath);
            foreach (VideoGame game in GameLibrary.Library)
            {
              Console.WriteLine($"Loaded {game.Alias} for {game.Platform}.");
            }
            break;
          case "list": // Lists all games in library.
              foreach (VideoGame game in GameLibrary.Library)
              {
                Console.WriteLine(game.Alias);
              }
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
            Console.WriteLine("load:    Loads library from disk.");
            Console.WriteLine("save:    Saves library to disk");
            Console.WriteLine("exit:    Exits the program.");
            break;
        }
      }
      
      
    }
  }