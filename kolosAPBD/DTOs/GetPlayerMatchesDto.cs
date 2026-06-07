using kolosAPBD.Entities;

namespace kolosAPBD.DTOs;

public class GetPlayerMatchesDto
{
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =  string.Empty;
    public DateTime BirthDate { get; set; }

    public IEnumerable<PlayerMatchDto> PlayerMatches { get; set; } = [];
}

public class PlayerMatchDto
{
    public string Tournament { get; set; }
    public string Map { get; set; }
    public DateTime MatchDate { get; set; }
    public int Mvps { get; set; }
    public double Rating { get; set; }
    public int Team1Score { get; set; }
    public int Team2Score { get; set; }
    public double BestRating { get; set; }
}

public class MatchDto
{
    
    
}