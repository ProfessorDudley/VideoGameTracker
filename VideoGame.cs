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