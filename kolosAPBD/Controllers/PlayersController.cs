using APBD_ex9.Exceptions;
using kolosAPBD.DTOs;
using kolosAPBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolosAPBD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        try
        {
            var result = await _playerService.GetPlayerMatches(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message); 
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayer([FromBody] PostPlayerDto dto)
    {
        try
        {
            await _playerService.AddPlayerWithMatches(dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message); 
        }
    }
}