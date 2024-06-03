namespace Spodify.Domain.Entities
{
    public class View
    {
        public int UserId { get; set; }
        public int MusicId { get; set; }
        public DateTime ViewedAt { get; set; }
    }
}
