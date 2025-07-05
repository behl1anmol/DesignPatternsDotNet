using MediatorPattern.Data;
using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Features.Players.CreatePlayer;

public class CreatePlayerCommandHandler(VideoGameAppDbContext context) :IRequestHandler<CreatePlayerCommand, Player>
{
    public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            Name = request.Name,
            Level = request.Level
        };
        context.Players.Add(player);
        await context.SaveChangesAsync(cancellationToken);
        return player;
    }
}