using MessagePack;

[MessagePackObject]
public class VideoGame
  {
    [Key(0)]
    public string Title { get; private set;}
    [Key(1)]
    public string DatePurchased { get; private set; }
    [Key(2)]
    public string Platform { get; private set; }
    [Key(3)]
    public bool Completed { get; private set; }
    [Key(4)]
    public string Alias { get; private set; }

    /// <summary>
    /// Video Game Object
    /// </summary>
    /// <param name="title">Game title</param>
    /// <param name="datePurchased">Date game was purchased</param>
    /// <param name="platform">Platform game is available on (not the vendor the game was purchased from)</param>
    /// <param name="alias">An alternative title. Used for sorting.</param>
    public VideoGame(string title, string datePurchased, string platform, bool completed = false, string? alias = null)
    {
      Title = title;
      Alias = alias ?? title; // Coalese operator. Returns left result if not null, otherwise right result.
      DatePurchased = datePurchased;
      Completed = completed;
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