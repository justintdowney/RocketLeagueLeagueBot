using Microsoft.EntityFrameworkCore;

namespace RLLBot.DAL.Models
{
    [Owned]
    public class Core
    {
        public int Shots { get; set; }
        public int ShotsAgainst { get; set; }
        public int Goals { get; set; }
        public int GoalsAgainst { get; set; }
        public int Saves { get; set; }
        public int Assists { get; set; }
        public int Score { get; set; }
        public bool Mvp { get; set; }
        public double ShootingPercentage { get; set; }
    }
}
