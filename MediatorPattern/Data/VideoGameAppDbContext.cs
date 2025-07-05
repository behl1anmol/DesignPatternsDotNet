using MediatorPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Data;

public class VideoGameAppDbContext(DbContextOptions<VideoGameAppDbContext> options) : DbContext(options)
{
    public DbSet<Player> Players { get; set; }
}