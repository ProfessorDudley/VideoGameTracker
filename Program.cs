using videogame;
using System.Text.Json;

class VideoGameTracker
  {
    static void Main(string[] args)
    {
      List<VideoGame> gameLibrary =
      [
        new VideoGame("Persona 5 Royal", "15/01/2019", "Steam"),
        new VideoGame("Yakuza Kiwami", "15/01/2019", "Steam", "Yakuza 1"),
        new VideoGame("Persona 4 Golden", "15/01/2019", "Steam"),
        new VideoGame("Dark Souls: Remastered", "15/01/2018", "Steam", "Dark Souls 1"),
        new VideoGame("Civilization 5", "15/01/2020", "Steam"),
        new VideoGame("Dragons Dogma", "15/01/2020", "Steam", "Dragons Dogma 1"),
        new VideoGame("Dragons Dogma 2", "15/01/2020", "Steam"),
        new VideoGame("Final Fantasy 14", "15/01/2020", "Steam"),
        new VideoGame("Eiyuden Chronicles", "15/01/2020", "Xbox"),
        new VideoGame("Hi-Fi Rush", "15/01/2020", "Xbox"),
        new VideoGame("Palworld", "15/01/2020", "Xbox"),
        new VideoGame("Dead Space Remake", "15/01/2023", "Xbox"),
        new VideoGame("The Legend of Zelda: Breath of the Wild", "15/01/2020", "Nintendo Switch"),
        new VideoGame("The Legend of Zelda: Tears of the Kingdom", "15/01/2020", "Nintendo Switch"),
        new VideoGame("New Super Mario Bros: Wonder", "15/01/2020", "Nintendo Switch"),
        new VideoGame("Mario Kart 8", "15/01/2020", "Nintendo Switch"),  
      ];

      string json = JsonSerializer.Serialize(gameLibrary);
      File.WriteAllText("./library.json", json);
      // List<VideoGame> gameLibrary = ImportJson("library.json");
      // foreach (VideoGame game in gameLibrary)
      // {
      //   Console.WriteLine($"Imported {game.Title} as {game.Alias}.");
      // }
      
    }

    static List<VideoGame> ImportJson(string path)
    {
      string jsonData = File.ReadAllText(path);
      List<VideoGame> ?parsedList = JsonSerializer.Deserialize<List<VideoGame>>(jsonData); // the ? before the variable name idicates that the value can be null in the instance there is no data read from the JSON Deserializer.
      return parsedList ?? []; // returns parsedList if not null, otherwise a new empty List<VideoGame> collection.
    }
  }