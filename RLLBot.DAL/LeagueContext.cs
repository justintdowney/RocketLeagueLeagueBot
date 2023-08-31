using Microsoft.EntityFrameworkCore;
using RLLBot.DAL.Models;

namespace RLLBot.DAL
{
    public class LeagueContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Replay> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Season> Seasons { get; set; }

        public LeagueContext(DbContextOptions options) : base(options) { }
    }
}
 