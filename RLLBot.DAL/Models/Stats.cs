using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RLLBot.DAL.Models
{
    [Owned]
    public class Stats
    {
        public Core Core { get; set; }
        public Boost Boost { get; set; }
        public Movement Movement { get; set; }
        public Positioning Positioning { get; set; }
        public Demo Demo { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }
    }
}
