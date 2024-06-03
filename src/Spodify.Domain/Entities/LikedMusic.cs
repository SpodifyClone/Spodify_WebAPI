namespace Spodify.Domain.Entities
{
    public class LikedMusic
    {
        public int UserId { get; set; }
        public int MusicId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
