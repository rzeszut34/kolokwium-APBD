namespace kolosAPBD.DTOs;

public class PostPlayerDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime BirthDate { get; set; }
    public List<PostPlayerMatchDto> Matches { get; set; } = [];
}

public class PostPlayerMatchDto
{
    public int MatchId { get; set; }
    public int Mvps { get; set; }
    public double Rating { get; set; }
}