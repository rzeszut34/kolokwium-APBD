namespace kolosAPBD.Entities;

public class PlayerMatch
{
    public int MatchId { get; set; }
    public int PlayerId { get; set; }
    public int Mvps { get; set; }
    public double Rating { get; set; }
    
    public Match Match { get; set; }
    public Player Player { get; set; }
}