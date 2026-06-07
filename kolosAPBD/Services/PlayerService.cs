using APBD_ex9.Exceptions;
using kolosAPBD.Data;
using kolosAPBD.DTOs;
using kolosAPBD.Entities;
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
    
    public async Task AddPlayerWithMatches(PostPlayerDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var newPlayer = new Player
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate
            };

            await _context.Players.AddAsync(newPlayer);
            await _context.SaveChangesAsync();

            foreach (var matchDto in dto.Matches)
            {
                var match = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == matchDto.MatchId);
                
                if (match == null)
                {
                    throw new NotFoundException($"Match with ID {matchDto.MatchId} does not exist.");
                }

                var playerMatch = new PlayerMatch
                {
                    PlayerId = newPlayer.PlayerId,
                    MatchId = matchDto.MatchId,
                    Mvps = matchDto.Mvps,
                    Rating = matchDto.Rating
                };

                await _context.PlayerMatches.AddAsync(playerMatch);

                if (match.BestRating == null || matchDto.Rating > match.BestRating)
                {
                    match.BestRating = matchDto.Rating;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (NotFoundException e)
        {
            await transaction.RollbackAsync();
            throw new NotFoundException(e.Message);
        }
    }
}