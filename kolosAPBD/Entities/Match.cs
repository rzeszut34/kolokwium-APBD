namespace kolosAPBD.Entities;

public class Match
{
    public int MatchId { get; set; }
    public DateTime MatchDate { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public double BestRating { get; set; }
    
    public int MapId { get; set; }
    public int TournamentId { get; set; }
    
    public Map Map { get; set; }
    public ICollection<PlayerMatch> PlayerMatches { get; set; } = [];
    public Tournament Tournament { get; set; }
}