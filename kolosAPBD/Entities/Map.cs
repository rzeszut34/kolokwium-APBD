namespace kolosAPBD.Entities;

public class Map
{
    public int MapId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;

    public ICollection<Match> Matches { get; set; } = [];
}