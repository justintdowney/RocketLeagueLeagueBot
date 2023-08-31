namespace RLLBot.DAL.Models
{
    public class Season
    {
        public int SeasonId { get; set; }
        public virtual ICollection<Replay> Games { get; set; }
    }
}
