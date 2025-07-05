using MediatorPattern.Models;
using MediatR;

namespace MediatorPattern.Features.Players.CreatePlayer;

//this is a dto object
public record CreatePlayerCommand(string Name, int Level) : IRequest<Player>;
