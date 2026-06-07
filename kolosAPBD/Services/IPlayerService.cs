using kolosAPBD.DTOs;
using kolosAPBD.Entities;

namespace kolosAPBD.Services;

public interface IPlayerService
{
    Task<GetPlayerMatchesDto> GetPlayerMatches(int playerId);
}