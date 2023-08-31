using System.Runtime.Serialization;

namespace RLLBot.DAL.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual Stats TeamStats { get; set; }
    }
}
