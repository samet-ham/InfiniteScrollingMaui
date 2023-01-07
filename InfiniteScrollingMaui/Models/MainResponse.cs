namespace InfiniteScrollingMaui.Models;

public class MainResponse
{
    public int Count { get; set; }
    public List<EntryDetails> Entries { get; set; }
}

public class EntryDetails
{
    public string API { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
