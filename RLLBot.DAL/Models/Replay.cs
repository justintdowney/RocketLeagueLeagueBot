namespace RLLBot.DAL.Models
{
    public class Replay
    {
        public string ReplayId { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public virtual Season Season { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
