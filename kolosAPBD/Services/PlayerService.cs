using APBD_ex9.Exceptions;
using kolosAPBD.Data;
using kolosAPBD.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolosAPBD.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;
    public PlayerService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<GetPlayerMatchesDto> GetPlayerMatches(int playerId)
    {
        var player = await _context.Players
            .Where(x => x.PlayerId == playerId)
            .Select(player => new GetPlayerMatchesDto()
            {
                PlayerId = player.PlayerId,
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthDate = player.BirthDate,
                PlayerMatches = player.PlayerMatches.Select(pm => new PlayerMatchDto()
                {
                    Tournament = pm.Match.Tournament.Name,
                    Map = pm.Match.Map.Name,
                    Mvps = pm.Mvps,
                    Rating = pm.Rating,
                    Team1Score = pm.Match.Team1Score,
                    Team2Score = pm.Match.Team2Score
                })
            }).FirstOrDefaultAsync();

        if (player == null)
        {
            throw new NotFoundException("Player not found");
        }

        return player;
    }
}