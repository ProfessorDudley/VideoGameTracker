using System.Text.Json;
using MessagePack;

namespace GameLibraryTracker
{
  static class GameLibrary
  {
    public static List<VideoGame> Library { get; private set; } = 
    [
      // new VideoGame("The Legend of Zelda: Breath of the Wild", "03/03/2017", "Nintendo Switch"),
      // new VideoGame("God of War", "04/20/2018", "PlayStation 4"),
      // new VideoGame("Halo Infinite", "12/08/2021", "Xbox Series X"),
      // new VideoGame("Cyberpunk 2077", "12/10/2020", "PC"),
    ];
    
    // Methods
    public static void Load(string path)
    {
      Console.Write("Loading games from disk... ");
      
      byte[] packed = File.ReadAllBytes(path + "data.dat");

      Library = LZ4MessagePackSerializer.Deserialize<List<VideoGame>>(packed);
      Console.WriteLine("done!");
    }

    public static void Save(string path)
    {
      Console.Write("Saving games to disk... ");

      // Save data using json. Human Readable.
      // string json = JsonSerializer.Serialize(Library);
      // File.WriteAllText(path + "data.json", json);

      // Save data using MessagePack. Binary.
      byte[] packed = LZ4MessagePackSerializer.Serialize<List<VideoGame>>(Library);
      File.WriteAllBytes(path + "data.dat", packed);

      Console.WriteLine("done!");
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

      Library.Add(new(title, datePurchased, platform, false, alias));

      Console.WriteLine($"{alias} added to library on {datePurchased} for {platform}.");
    }

    public static void ListGames(string platform)
    {
      List<VideoGame> games = Library.FindAll(g => string.Equals(g.Platform, platform, StringComparison.OrdinalIgnoreCase));
      if (games.Count == 0) Console.WriteLine($"No games for {platform}");
      foreach (VideoGame game in games) Console.WriteLine($"{game.Title} for {game.Platform}");
    }

    public static void RemoveGame(string game)
    {
      VideoGame? target = Library.Find(g => string.Equals(g.Title, game, StringComparison.OrdinalIgnoreCase));
      if (target != null)
      {
        Console.WriteLine($"Removed {target.Title} from the library");
        Library.Remove(target);
      } else
      {
        Console.WriteLine("Unable to remove {game} from library");
      }
    }
  }
}