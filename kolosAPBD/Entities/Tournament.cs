namespace kolosAPBD.Entities;

public class Tournament
{
    public int TournamentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public ICollection<Match> Matches { get; set; } = [];
}