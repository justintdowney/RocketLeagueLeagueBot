namespace RLLBot.DAL.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Tier { get; set; }
        public virtual Stats PlayerStats { get; set; }
        public virtual ICollection<Replay> Games { get; set; }
        public virtual Team Team { get; set; }
        public virtual Season Season { get; set; }

    }
}
