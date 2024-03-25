using System.Text.Json;

namespace GameLibraryTracker
{
  static class GameLibrary
  {
    public static List<VideoGame> Library { get; private set; } = [];
    
    // Methods
    public static void LoadGames(string path)
    {
      Console.Write("Loading games from disk... ");
      string jsonData = File.ReadAllText(path);
      List<VideoGame>? parsedList;
      try
      {
        // the ? after the type idicates that the value can be null in a situation where there is no data read from the JSON Deserializer.
        parsedList = JsonSerializer.Deserialize<List<VideoGame>>(jsonData);
      }
      catch (JsonException)
      {
        parsedList = [];
      }
      
      Library = parsedList ?? []; // returns parsedList if not null, otherwise a new empty List<VideoGame> collection.
      Console.WriteLine("done!");
    }
    public static void WriteOut(string path)
    {
      string json = JsonSerializer.Serialize(Library);
      File.WriteAllText(path, json);
    }
    public static void AddGame()
    {
      // Set Title
      SetTitle:
      Console.Write("Game Title: ");
      string? title = Console.ReadLine() ?? string.Empty;
      if (title == string.Empty) 
      {
        Console.WriteLine("Games must have a title");
        goto SetTitle;
      }

      // Set Date Purchased
      Console.Write("Date Purchased: ");
      string? datePurchased = Console.ReadLine() ?? string.Empty;
      if (datePurchased == string.Empty) datePurchased = DateTime.Today.ToString("d");

      // Set Platform
      SetPlatform:
      Console.Write("Game Platform: ");
      string? platform = Console.ReadLine() ?? string.Empty;
      if (platform == string.Empty)
      {
        Console.WriteLine("Games must have a platform");
        goto SetPlatform;
      }

      // Set alias
      Console.Write("Game Alias: ");
      string? alias = Console.ReadLine() ?? string.Empty;
      if (alias == string.Empty) alias = title;

      Library.Add(new(title, datePurchased, platform, alias));

      Console.WriteLine($"{alias} added to library on {datePurchased} for {platform}.");
    }
  }
  
  class VideoGame
  {
    public string Title { get; private set;}
    public string Alias { get; private set; }
    public string DatePurchased { get; private set; }
    public bool Completed { get; private set; }
    public string Platform { get; private set; }

    /// <summary>
    /// Video Game Object
    /// </summary>
    /// <param name="title">Game title</param>
    /// <param name="datePurchased">Date game was purchased</param>
    /// <param name="platform">Platform game is available on (not the vendor the game was purchased from)</param>
    /// <param name="alias">An alternative title. Used for sorting.</param>
    public VideoGame(string title, string datePurchased, string platform, string? alias = null)
    {
      Title = title;
      Alias = alias ?? title; // Coalese operator. Returns left result if not null, otherwise right result.
      DatePurchased = datePurchased;
      Completed = false;
      Platform = platform;

      // Console.WriteLine($"{Title} --> {Alias}");
    }

    /// <summary>
    /// Sets an alias for this game. Alias' are used for sorting.
    /// </summary>
    /// <param name="alias"></param>
    public void SetAlias(string alias) => Alias = alias; // Single line function.
    public void MarkCompleted() => Completed = true; // Single line function.
  }
}