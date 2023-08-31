using Microsoft.EntityFrameworkCore;

namespace RLLBot.DAL.Models
{
    [Owned]
    public class Movement
    {
        public int AvgSpeed { get; set; }
        public int TotalDistance { get; set; }
        public double TimeSupersonicSpeed { get; set; }
        public double TimeBoostSpeed { get; set; }
        public double TimeSlowSpeed { get; set; }
        public double TimeGround { get; set; }
        public double TimeLowAir { get; set; }
        public double TimeHighAir { get; set; }
        public double TimePowerslide { get; set; }
        public int CountPowerslide { get; set; }
        public double AvgPowerslideDuration { get; set; }
        public double AvgSpeedPercentage { get; set; }
        public double PercentSlowSpeed { get; set; }
        public double PercentBoostSpeed { get; set; }
        public double PercentSupersonicSpeed { get; set; }
        public double PercentGround { get; set; }
        public double PercentLowAir { get; set; }
        public double PercentHighAir { get; set; }
    }
}   
