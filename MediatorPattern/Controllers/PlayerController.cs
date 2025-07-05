using MediatorPattern.Data;
using MediatorPattern.Features.Players.CreatePlayer;
using MediatorPattern.Features.Players.GetPlayerById;
using MediatorPattern.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorPattern.Controllers;

[ApiController]
[Route("/api")]
public class PlayerController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand player)
    {
        var playerResponse = await sender.Send(player);
        return Ok(playerResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerById(int id)
    {
        var player = await sender.Send(new GetPlayerByIdQuery(id));
        if(player is null) return NotFound();
        return Ok(player);
    }
}