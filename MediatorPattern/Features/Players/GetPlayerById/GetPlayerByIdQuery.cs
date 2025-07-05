using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Features.Players.GetPlayerById;

public record GetPlayerByIdQuery(int Id) : IRequest<Player?>;
