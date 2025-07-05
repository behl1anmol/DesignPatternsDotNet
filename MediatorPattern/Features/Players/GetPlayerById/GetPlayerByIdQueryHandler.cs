using MediatorPattern.Data;
using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Features.Players.GetPlayerById;

public class GetPlayerByIdQueryHandler(VideoGameAppDbContext context) : IRequestHandler<GetPlayerByIdQuery, Player?>
{
    public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await context.Players.FindAsync(request.Id, cancellationToken);
        return player;
    }
}