namespace Spodify.Domain.Entities
{
    public class LikedPlaylist
    {
        public int UserId { get; set; }
        public int PlaylistId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
